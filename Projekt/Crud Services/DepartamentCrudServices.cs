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

        public async Task<Departments> AddBrand(int id, string Type, string Liability)
        {
            try
            {
                if (Type == string.Empty && Liability == string.Empty)
                {
                    throw new Exception("Type And Liability Cannot be Empty");
                }
                else
                {
                    Departments br = new Departments
                    {
                        Id = id,
                        Type = Type,
                        Liability = Liability

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
                Departments delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ICollection<Departments>> ListBrands()
        {


            return (ICollection<Departments>)await _crudServices.GetAll();


        }
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

        public async Task<Departments> UpdateBrand(int id, string Type, string Liability)
        {
            try
            {
                Departments br = await SearchBrandbyID(id);
                br.Type = Type;
                br.Liability = Liability;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}