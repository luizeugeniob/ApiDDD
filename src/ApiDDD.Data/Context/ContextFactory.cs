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
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "sqlserver")
                optionsBuilder.UseSqlServer(connectionString);
            else
                optionsBuilder.UseMySql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}
