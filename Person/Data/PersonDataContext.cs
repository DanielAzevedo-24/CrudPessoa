using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Person.models;

namespace Person.Data
{
    public class PersonContext : DbContext
    {
     public required DbSet<PersonModels> People {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString:"Data Source=person.Sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}