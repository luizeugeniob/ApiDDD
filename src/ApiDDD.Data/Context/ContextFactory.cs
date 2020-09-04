using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ApiDDD.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        /// <summary>
        /// Create migrations in execution time.
        /// </summary>
        public MyContext CreateDbContext(string[] args)
        {
            //var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            //if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "sqlserver")
            //    optionsBuilder.UseSqlServer(connectionString);
            //else
            //    optionsBuilder.UseMySql(connectionString);

            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=dbAPI;MultipleActiveResultSets=true;User ID=sa;Password=15974");

            return new MyContext(optionsBuilder.Options);
        }
    }
}
