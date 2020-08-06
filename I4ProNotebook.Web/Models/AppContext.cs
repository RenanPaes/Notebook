using I4PRONotebook.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace I4ProNotebook.Web.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasKey(t => t.ID);
            modelBuilder.Entity<Contact>().HasMany(t => t.PhoneNumbers).WithOne(t => t.Contact);
            modelBuilder.Entity<Contact>().HasMany(t => t.Emails).WithOne(t => t.Contact);

            modelBuilder.Entity<Email>().HasKey(t => t.ID);
            modelBuilder.Entity<Email>().HasOne(t => t.Contact).WithMany(t => t.Emails);

            modelBuilder.Entity<PhoneNumber>().HasKey(t => t.ID);
            modelBuilder.Entity<PhoneNumber>().HasOne(t => t.Contact).WithMany(t => t.PhoneNumbers);
        }
    }
}
