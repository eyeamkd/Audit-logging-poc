﻿using Microsoft.EntityFrameworkCore;

namespace AuditLoggerPoc
{
    public class UserDatabaseContext : DbContext
    { 
        public DbSet<User> Users { get; set; }

        public DbSet<AuditTrailData> AuditTrails { get; set; }

        public string DbPath { get; }

        public UserDatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "users.db");
            Console.WriteLine("DB path is "+DbPath);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");


    }
}
