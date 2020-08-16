using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiDDD.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        /// <summary>
        /// Create migrations in execution time.
        /// </summary>
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=masterkey";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
