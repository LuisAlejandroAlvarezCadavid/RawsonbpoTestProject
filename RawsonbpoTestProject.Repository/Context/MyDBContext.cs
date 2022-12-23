using Microsoft.EntityFrameworkCore;
using RawsonbpoTestProject.Repository.DataModel;

namespace RawsonbpoTestProject.Repository.Context
{
    public class MyDBContext: DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            base.OnConfiguring(options);
            options.UseSqlServer("Data Source=localhost;Initial Catalog=DbTestSqlServer;User Id=Alejandro;password=Alejo.1234;Encrypt=False");
        }

       
    }
}
