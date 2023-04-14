using Projekt.Models;
using Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Crud_Services
{
    public class ShiftCrudServices
    {
        
        private readonly IDataService<Shifts> _crudServices;

        public ShiftCrudServices()
        {
            _crudServices = new GenericDataService<Shifts>(new CrudFactory());
        }
        /// <summary>
        /// Funckja służąca do dodania danych w tabeli Shifts
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Type"></param>
        /// <param name="Shours"></param>
        /// <param name="Fhours"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Shifts> AddBrand(int id, string Type, string Shours, string Fhours)
        {
            try
            {
                if (Shours == string.Empty && Fhours == string.Empty)
                {
                    throw new Exception("Start Hours And Finish Hours Cannot be Empty");
                }
                else
                {
                    Shifts br = new Shifts
                    {
                       Id = id,
                       Type = Type,
                       Shours = Shours,
                       Fhours = Fhours

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
        /// Funckja służąca do usuwania danych w tabeli Shifts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                Shifts delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Funckja pobierająca dane z Shifts
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Shifts>> ListBrands()
        {


            return (ICollection<Shifts>)await _crudServices.GetAll();


        }
        /// <summary>
        /// Funckja służąca do wyszukania danych po ID
        /// </summary>
        /// <returns></returns>
        public Task<Shifts> SearchBrandbyID(int ID)
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
        public async Task<ICollection<Shifts>> SearchBrandByName(string Type)
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
        /// Funckja służąca do aktualizacji danych w tabeli Shifts
        /// </summary>
        /// <returns></returns>
        public async Task<Shifts> UpdateBrand(int id, string Type , string Shours , string Fhours)
        {
            try
            {
                Shifts br = await SearchBrandbyID(id);
                br.Type = Type;
                br.Shours = Shours;
                br.Fhours = Fhours;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}


