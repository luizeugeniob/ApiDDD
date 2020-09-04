using ApiDDD.Data.Mapping;
using ApiDDD.Data.Seeds;
using ApiDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiDDD.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@mail.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                });

            modelBuilder.Entity<StateEntity>(new StateMap().Configure);
            modelBuilder.Entity<CityEntity>(new CityMap().Configure);
            modelBuilder.Entity<AddressEntity>(new AddressMap().Configure);

            StateSeeds.States(modelBuilder);
        }
    }
}
