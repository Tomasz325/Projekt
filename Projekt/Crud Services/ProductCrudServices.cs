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
    public class ProductCrudServices
    {
        private readonly IDataService<Products> _crudServices;

        public ProductCrudServices()
        {
            _crudServices = new GenericDataService<Products>(new CrudFactory());
        }
        /// <summary>
        /// Funkcja służąca do dodania rekordu w tabelii Products
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Products> AddBrand(int id, string type, string name, double quantity, double price)
        {
            try
            {
                if (name == string.Empty && type == string.Empty)
                {
                    throw new Exception("Product Name And Product Type Cannot be Empty");
                }
                else
                {
                    Products br = new Products
                    {
                        Id = id,
                        Type = type,
                        Name = name,
                        Quantity = quantity,
                        Price = price

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
        /// Funkcja służąca do usuwania rekordu w tabelii Departments
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                Products delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Funckja pobierająca dane z Products(w relacji z Departaments)
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Products>> ListBrands()
        {

            var context = new CrudFactory();

            return (ICollection<Products>)await context.CreateDbContext().Products.Include(p => p.departments).ToListAsync();


        }
        /// <summary>
        /// Funckja służąca do wyszukania danych po ID
        /// </summary>
        /// <returns></returns>
        public Task<Products> SearchBrandbyID(int ID)
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
        public async Task<ICollection<Products>> SearchBrandByName(string name)
        {
            try
            {
                var listbrand = await ListBrands();
                return listbrand.Where(x => x.Name.StartsWith(name)).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// Funckja służąca do aktualizacji danych w tabeli Products
        /// </summary>
        /// <returns></returns>
        public async Task<Products> UpdateBrand(int id, string type, string name, double quantity, double price)
        {
            try
            {
                Products br = await SearchBrandbyID(id);
                br.Type = type;
                br.Name = name;
                br.Quantity = quantity;
                br.Price = price;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}