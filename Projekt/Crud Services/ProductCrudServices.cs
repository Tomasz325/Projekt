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
        public async Task<ICollection<Products>> ListBrands()
        {


            return (ICollection<Products>)await _crudServices.GetAll();


        }
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