using Microsoft.EntityFrameworkCore;
using PersonApi.Models;
using System.Xml.Linq;

namespace PersonApi
{
    /// <summary>
    /// AppDbContext from de database
    /// </summary>
    public class AppDbContext : DbContext
    {
        private string _name;
        public AppDbContext(string dbName = $"Data Source=Database/EonixTestDb.sqlite")
        {
            _name= dbName;
        }

        /// <summary>
        /// Set of person from de database
        /// </summary>
        public DbSet<Person> Persons { get; set; }


        //
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_name);

    }
}
