using Projekt.Models;
using Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Crud_Services
{
    public class WorkerCrudServices 

    {
        private readonly IDataService<Worker> _crudServices;

        public WorkerCrudServices()
        {
            _crudServices = new GenericDataService<Worker>(new CrudFactory());
        }

        public async Task<Worker> AddBrand(int id, string name, string lastname , int age, string address, string postalcode)
        {
            try
            {
                if (name == string.Empty && lastname == string.Empty)
                {
                    throw new Exception("Worker Name And Lastname Cannot be Empty");
                }
                else
                {
                    Worker br = new Worker
                    {
                        Id = id,
                        Name = name,
                        Lastname = lastname,
                        Age = age,
                        Address = address,
                        Postalcode = postalcode
                        
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
                Worker delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ICollection<Worker>> ListBrands()
        {
            
            
         return (ICollection<Worker>)await _crudServices.GetAll();
            
           
        }
        public Task<Worker> SearchBrandbyID(int ID)
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

        public async Task<ICollection<Worker>> SearchBrandByName(string name)
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

        public async Task<Worker> UpdateBrand(int id, string name, string lastname, int age, string address, string postalcode)
        {
            try
            {
                Worker br = await SearchBrandbyID(id);
                br.Name = name;
                br.Lastname = lastname;
                br.Age = age;
                br.Address = address;
                br.Postalcode = postalcode;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}