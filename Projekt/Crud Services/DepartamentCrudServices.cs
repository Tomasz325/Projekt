using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Crud_Services
{
    public class DepartamentCrudServices
    {

        private readonly IDataService<Departments> _crudServices;

        public DepartamentCrudServices()
        {
            _crudServices = new GenericDataService<Departments>(new CrudFactory());
        }
        /// <summary>
        /// Funkcja służąca do dodania rekordu w tabeli Departments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Type"></param>
        /// <param name="Workers"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Departments> AddBrand(int id, string Type, int Workers)
        {
            var context = new CrudFactory().CreateDbContext();
            try
            {
              var worker = await context.Workers.FindAsync(Workers);
                if (Type == string.Empty )
                {
                    throw new Exception("Type Cannot be Empty");
                }
                else
                {
                    var work = new List<Worker>();
                    work.Add(worker);
                    Departments br = new Departments()
                    {
                        Id = id,
                        Type = Type,
                        Workers = work.ToHashSet(),

                    };
                    context.Departments.Add(br);
                    await context.SaveChangesAsync();
                    return br; 
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Funkcja dodająca produkt do tabeli Departaments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Departments> AddProduct(int id, int productId)
        {
            var context = new CrudFactory().CreateDbContext();
            var departament = await context.Departments.FindAsync(id);
            var product = await context.Products.FindAsync(productId);
            if (product == null) { throw new Exception("Podanego produktu nie ma w bazie"); }
            departament.products.Add(product);
            await context.SaveChangesAsync();
            return departament;

        }
        /// <summary>
        /// Funkcja usuwająca produkt z tabeli Departments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ICollection<Departments>> DeleteProduct(int id, int productId)
        {
            var context = new CrudFactory().CreateDbContext();
            var departament = await context.Departments.Include(d => d.products).FirstAsync(d => d.Id == id);
            var products = await context.Products.FindAsync(productId);
            var product = departament.products.FirstOrDefault(p => p.Id == productId);
            if (product == null) { throw new Exception("Podanego produktu nie ma w bazie"); }
            departament.products.Remove(product);
            await context.SaveChangesAsync();
            return await context.Departments.ToListAsync();
        }
        /// <summary>
        /// Funkcja usuwająca rekord z tabeli Departments
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                Departments delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Funckja pobierająca dane z Departaments(w relacji z Products oraz Worker)
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Departments>> ListBrands()
        {

            var context = new CrudFactory();

            return (ICollection<Departments>)await context.CreateDbContext().Departments.Include(d => d.products).Include(d => d.Workers).ToListAsync();


        }
        /// <summary>
        /// Funkcja służąca do wyszukania po parametrze ID w tabeli Departments
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task<Departments> SearchBrandbyID(int ID)
        {
            try
            {
                return _crudServices.Get(ID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Funckja służąca do wyszukania po parametrze Name w tabelii Departments
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ICollection<Departments>> SearchBrandByName(string Type)
        {
            try
            {
                var listbrand = await ListBrands();
                return listbrand.Where(x => x.Type.StartsWith(Type)).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// Funkcja służąca do aktualizacji rekordu w tabeli Departments
        /// </summary>
        /// <returns></returns>
        public async Task<Departments> UpdateBrand(int id, string Type, int Workers)
        {
            var context = new CrudFactory().CreateDbContext();
            try
            {
                var worker = await context.Workers.FindAsync(Workers);
                var work = new List<Worker>();
                work.Add(worker);
                Departments update = await context.Departments.FindAsync(id);
                context.Departments.Remove(update);
                context.Departments.Add(new Departments() { Type = Type, Workers = work.ToHashSet() });
                await context.SaveChangesAsync();
                return update;
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}