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

    public async Task<Suppliers> AddBrand(int id, string Name, string Type, string Carsize)
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
                    Carsize = Carsize

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
            Suppliers delete = await SearchBrandbyID(id);

            return await _crudServices.Delete(delete);



        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<ICollection<Suppliers>> ListBrands()
    {


        return (ICollection<Suppliers>)await _crudServices.GetAll();


    }
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

    public async Task<Suppliers> UpdateBrand(int id, string Name, string Type, string Carsize)
    {
        try
        {
            Suppliers br = await SearchBrandbyID(id);
            br.Name = Name;
            br.Type = Type;
            br.Carsize = Carsize;
            return await _crudServices.Update(br);


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }

    }
}
}

  
