using Microsoft.EntityFrameworkCore;
using OrderApi.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderApi.DataAccess
{
    public class OrderDbContext : DbContext
    {
        string pathGroups = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        bool eraseDatabase = true;
        public OrderDbContext()
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

            modelBuilder.Entity<Order>().HasData(AddOrderSeed());
          
        }

        private static List<Order> AddOrderSeed()
        {
            List<Order> orders = new List<Order>();
            for (int i = 1; i < 4; i++)
            {
                Order order = new Order();
                order.Id = i;
                order.OrderState = i;
                order.CustomerFullName = "Customer" + i.ToString();
                order.CustomerId = i;
                orders.Add(order);
            }

            return orders;
        }


     

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=" + pathGroups + "DynamicDB.db");
        }

        public virtual DbSet<Order> Orders { get; set; }

    }
}
