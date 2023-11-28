using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using School.API.Models;

namespace School.API
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            :base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            try
            {
                if(databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.CreateAsync();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTablesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public DbSet<Student> Students { get; set; }
    }
}
