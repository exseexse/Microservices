using CustomerApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerApi.DataAccess
{
    public class CustomerDbContext : DbContext
    {
        string pathGroups = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        bool eraseDatabase = true;
        public CustomerDbContext()
        {
            //if (!File.Exists(pathGroups + "FriendOrganizerDb.db"))
            //{
            //    Database.EnsureDeleted();
            //    Database.EnsureCreated();
            //}
            if (eraseDatabase)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                eraseDatabase = false;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(AddCustomerSeed());
            modelBuilder.Entity<PhoneNumber>().HasData(AddPhoneNumberSeed());
            modelBuilder.Entity<Language>().HasData(
              new { Id = 1, Name = "German" },
              new { Id = 2, Name = "English" },
              new { Id = 3, Name = "Turkish" }
          );
        }

        private static List<Customer> AddCustomerSeed()
        {
            List<Customer> friends = new List<Customer>();
            for (int i = 1; i < 4; i++)
            {
                Customer friend = new Customer();
                friend.Id = i;
                friend.FirstName = "N" + i.ToString();
                friend.LastName = "L" + i.ToString();
                friend.Email = "E" + i.ToString();
                friends.Add(friend);
            }

            return friends;
        }


        private static List<PhoneNumber> AddPhoneNumberSeed()
        {
            List<PhoneNumber> friendPhoneNumbers = new List<PhoneNumber>();
            for (int i = 1; i < 4; i++)
            {
                PhoneNumber friendPhoneNumber = new PhoneNumber();
                friendPhoneNumber.Id = i;
                friendPhoneNumber.Number = "+49 1234567" + i.ToString();
                friendPhoneNumber.CustomerId = i;
                friendPhoneNumbers.Add(friendPhoneNumber);
            }

            return friendPhoneNumbers;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=" + pathGroups + "DynamicDB.db");
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
