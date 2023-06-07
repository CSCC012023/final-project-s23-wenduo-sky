﻿using Microsoft.EntityFrameworkCore;
using yourscope_api.Models.DbModels;

namespace yourscope_api
{
    public class YourScopeContext : DbContext
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = config.GetConnectionString("db");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
