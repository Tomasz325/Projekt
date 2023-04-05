using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models;

namespace Projekt.Crud_Services
{
    public class CrudFactory : IDesignTimeDbContextFactory<DBContext>
    {
       /* public DBContext CreateDbContext(string[] args = null)
        {
            
            var options = new DbContextOptionsBuilder<DBContext>();
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "Supermarket.db");
            options.UseSqlite($"Data Source={DbPath}");
            return new DBContext(options.Options);
        }*/

       public DBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DBContext>();
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "Supermarket.db");
            options.UseSqlite($"Data Source={DbPath}");
            return new DBContext(options.Options);
        }
    }
}