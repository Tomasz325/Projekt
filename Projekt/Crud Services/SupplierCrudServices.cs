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
    public class SupplierCrudServices { 
                private readonly IDataService<Suppliers> _crudServices;

    public SupplierCrudServices()
    {
        _crudServices = new GenericDataService<Suppliers>(new CrudFactory());
    }
        /// <summary>
        /// Funckja służąca do dodania danych w tabeli Suppliers
        /// </summary>
        /// <returns></returns>
        public async Task<Suppliers> AddBrand(int id, string Name, string Type, string Carmodel)
    {
        try
        {
            if (Name == string.Empty && Type == string.Empty)
            {
                throw new Exception("Supplier Name And Car Type Cannot be Empty");
            }
            else
            {
                Suppliers br = new Suppliers
                {
                    Id = id,
                    Name = Name,
                    Type = Type,
                    Carmodel = Carmodel

                };
                return await _crudServices.Create(br);
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
        /// <summary>
        /// Dodaję produkt do tabeli Suppliers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Suppliers> AddProduct(int id, int productId)
        {
            var context = new CrudFactory().CreateDbContext();
            var supplier = await context.Suppliers.FindAsync(id);
            var product = await context.Products.FindAsync(productId);
            if (product == null) { throw new Exception("Podanego produktu nie ma w bazie"); }
            supplier.products.Add(product);
            await context.SaveChangesAsync();
            return supplier;

        }
        /// <summary>
        /// Funckja służąca do usuwania danych w tabeli Suppliers
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteBrand(int id)
    {
        try
        {
            Suppliers delete = await SearchBrandbyID(id);

            return await _crudServices.Delete(delete);



        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
        /// <summary>
        /// Usuwa produkt z tabelii Suppliers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ICollection<Suppliers>> DeleteProduct(int id, int productId)
        {
            var context = new CrudFactory().CreateDbContext();
            var supplier = await context.Suppliers.Include(s => s.products).FirstAsync(s => s.Id == id);
            var products = await context.Products.FindAsync(productId);
            var product = supplier.products.FirstOrDefault(p => p.Id == productId);
            if (product == null) { throw new Exception("Podanego produktu nie ma w bazie"); }
            supplier.products.Remove(product);
            await context.SaveChangesAsync();
            return await context.Suppliers.ToListAsync();
        }
        /// <summary>
        /// Funckja pobierająca dane z Suppliers(w relacji z Products)
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Suppliers>> ListBrands()
    {


            var context = new CrudFactory();

            return (ICollection<Suppliers>)await context.CreateDbContext().Suppliers.Include(s => s.products).ToListAsync();


        }
        /// <summary>
        /// Funckja służąca do wyszukania danych po ID
        /// </summary>
        /// <returns></returns>
        public Task<Suppliers> SearchBrandbyID(int ID)
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
        /// Funckja służąca do wyszukania danych po Name
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Suppliers>> SearchBrandByName(string Type)
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
        /// Funckja służąca do aktualizacji danych w tabeli Suppliers
        /// </summary>
        /// <returns></returns>
        public async Task<Suppliers> UpdateBrand(int id, string Name, string Type, string Carmodel)
    {
        try
        {
            Suppliers br = await SearchBrandbyID(id);
            br.Name = Name;
            br.Type = Type;
            br.Carmodel = Carmodel;
            return await _crudServices.Update(br);


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }

    }
}
}

  
