using Microsoft.EntityFrameworkCore;
using lacrosseDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace lacrosseDB
{
    /// <summary>
    /// The class that is responsible for connecting, updating the database 
    /// </summary>
    public class lacrosseContext : DbContext
    {
        /// <summary>
        /// A table in the database for customers
        /// </summary>
        /// <value></value>
        public DbSet<Customer> Customer {get; set;}

        /// <summary>
        /// A table in the database for managers
        /// </summary>
        /// <value></value>
        public DbSet<Manager> Managers {get; set;} 

        /// <summary>
        /// A table in the database for sticks
        /// </summary>
        /// <value></value>
        public DbSet<Sticks> Product {get; set;}

        /// <summary>
        /// A table in the database for orders
        /// </summary>
        /// <value></value>
        public DbSet<Orders> Orders {get; set;}

        /// <summary>
        /// A table in the database for locations
        /// </summary>
        /// <value></value>
        public DbSet<Locations> Locations {get; set;}

        /// <summary>
        /// A table in the database for inventory
        /// </summary>
        /// <value></value>
        public DbSet<Inventory> Inventory {get; set;}

        /// <summary>
        /// A table in the database for cart
        /// </summary>
        /// <value></value>
        public DbSet<Cart> Cart {get; set;}

        /// <summary>
        /// A table in the database for cartitems
        /// </summary>
        /// <value></value>
        public DbSet<CartItem> CartItem {get; set;}

        public DbSet<lineItem> LineItem {get; set;}

        /// <summary>
        /// telling lacrosse context where the database is and then connecting to it 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("lacrosseDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        /// <summary>
        /// helping to get rid of the one to many relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // var StickConverter1 = new EnumToStringConverter<Sticks.BrandType>();
            // //var StickConverter2 = new EnumToStringConverter<Sticks.StickType>();
            // var BallConverter = new EnumToStringConverter<Balls.ColorType>();

            // modelBuilder.Entity<Sticks>() 
            // .Property(s => s.brandType)
            // .HasConversion(StickConverter1);

            // // modelBuilder.Entity<Sticks>()
            // // .Property(s => s.stickType)
            // // .HasConversion(StickConverter2);

            // modelBuilder.Entity<Balls>() 
            // .Property(b => b.colorType)
            // .HasConversion(BallConverter);
        }
    }
}