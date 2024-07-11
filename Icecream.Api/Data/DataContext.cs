using Icecream.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Icecream.Api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<IceCream> IceCreams { get; set; }
        public DbSet<IceCreamOption> IceCreamOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IceCreamOption>()
                 .HasKey(io => new { io.IceCreamId, io.Flavor, io.Topping });
            AddSeedData(modelBuilder);
        }
        private static void AddSeedData(ModelBuilder modelBuilder)
        {
            IceCream[] IceCreams = [
                new IceCream { Id = 1, Name = "Vanilla Delight", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_0.jpg", Price = 6.25 },
            new IceCream { Id = 2, Name = "ChocoBerry Bliss", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_1.jpg", Price = 7.5 },
            new IceCream { Id = 3, Name = "Minty Cookie Crunch", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_2.jpg", Price = 8.75 },
            new IceCream { Id = 4, Name = "Strawberry Dream", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_3.jpg", Price = 6.95 },
            new IceCream { Id = 5, Name = "Cookie Dough Extravaganza", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_4.jpg", Price = 9.2 },
            new IceCream { Id = 6, Name = "Caramel Swirl Symphony", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_5.jpg", Price = 7.75 },
            new IceCream { Id = 7, Name = "Peanut Butter Paradise", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_6.jpg", Price = 8.5 },
            new IceCream { Id = 8, Name = "Mango Tango Tango", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_7.jpg", Price = 9.8 },
            new IceCream { Id = 9, Name = "Hazelnut Heaven", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_8.jpg", Price = 8.95 },
            new IceCream { Id = 10, Name = "Blueberry Bliss Bonanza", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_9.jpg", Price = 7.2 },
            new IceCream { Id = 11, Name = "Toffee Twist Temptation", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_10.jpg", Price = 7.95 },
            new IceCream { Id = 12, Name = "Rocky Road Revelry", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_11.jpg", Price = 9.5 },
            new IceCream { Id = 13, Name = "Passionfruit Paradise", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_12.jpg", Price = 8.75 },
            new IceCream { Id = 14, Name = "Cotton Candy Carnival", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_13.jpg", Price = 7.2 },
            new IceCream { Id = 15, Name = "Lemon Sorbet Serenity", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_14.jpg", Price = 6.9 },
            new IceCream { Id = 16, Name = "Maple Pecan Pleasure", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_15.jpg", Price = 8.25 },
            new IceCream { Id = 17, Name = "Raspberry Ripple Rhapsody", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_16.jpg", Price = 7.45 },
            new IceCream { Id = 18, Name = "Almond Joyful Jubilee", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_17.jpg", Price = 9.95 },
            new IceCream { Id = 19, Name = "Blue Lagoon Bliss", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_18.jpg", Price = 8.5 },
            new IceCream { Id = 20, Name = "Coconut Caramel Carnival", Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/IceCreams/small/ic_19.jpg", Price = 7.8 }
            ];

            IceCreamOption[] IceCreamOptions = [
                new IceCreamOption { IceCreamId = 1, Flavor = "Vanilla", Topping = "Default" },
            new IceCreamOption { IceCreamId = 1, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 1, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 2, Flavor = "Chocolate", Topping = "Default" },
            new IceCreamOption { IceCreamId = 2, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 2, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 3, Flavor = "Mint Chocolate Chip", Topping = "Default" },
            new IceCreamOption { IceCreamId = 3, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 3, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 4, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 4, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 4, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 5, Flavor = "Cookie Dough", Topping = "Default" },
            new IceCreamOption { IceCreamId = 5, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 5, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 6, Flavor = "Vanilla", Topping = "Default" },
            new IceCreamOption { IceCreamId = 6, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 6, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 7, Flavor = "Chocolate", Topping = "Default" },
            new IceCreamOption { IceCreamId = 7, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 7, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 8, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 8, Flavor = "Cookie Dough", Topping = "Default" },
            new IceCreamOption { IceCreamId = 8, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 9, Flavor = "Mint Chocolate Chip", Topping = "Default" },
            new IceCreamOption { IceCreamId = 9, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 9, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 10, Flavor = "Chocolate", Topping = "Default" },
            new IceCreamOption { IceCreamId = 10, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 10, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 11, Flavor = "Vanilla", Topping = "Default" },
            new IceCreamOption { IceCreamId = 11, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 11, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 12, Flavor = "Chocolate", Topping = "Default" },
            new IceCreamOption { IceCreamId = 12, Flavor = "Mint Chocolate Chip", Topping = "Default" },
            new IceCreamOption { IceCreamId = 12, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 13, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 13, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 13, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 14, Flavor = "Cookie Dough", Topping = "Default" },
            new IceCreamOption { IceCreamId = 14, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 14, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 15, Flavor = "Vanilla", Topping = "Default" },
            new IceCreamOption { IceCreamId = 15, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 15, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 16, Flavor = "Chocolate", Topping = "Default" },
            new IceCreamOption { IceCreamId = 16, Flavor = "Mint Chocolate Chip", Topping = "Default" },
            new IceCreamOption { IceCreamId = 16, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 17, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 17, Flavor = "Cookie Dough", Topping = "Default" },
            new IceCreamOption { IceCreamId = 17, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 18, Flavor = "Vanilla", Topping = "Default" },
            new IceCreamOption { IceCreamId = 18, Flavor = "Default", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 18, Flavor = "Default", Topping = "Cherries" },
            new IceCreamOption { IceCreamId = 19, Flavor = "Chocolate", Topping = "Default" },
            new IceCreamOption { IceCreamId = 19, Flavor = "Strawberry", Topping = "Default" },
            new IceCreamOption { IceCreamId = 19, Flavor = "Default", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 20, Flavor = "Mint Chocolate Chip", Topping = "Default" },
            new IceCreamOption { IceCreamId = 20, Flavor = "Default", Topping = "Chocolate Sauce" },
            new IceCreamOption { IceCreamId = 20, Flavor = "Default", Topping = "Sprinkles" }
            ];

            modelBuilder.Entity<IceCream>()
                .HasData(IceCreams);

            modelBuilder.Entity<IceCreamOption>()
                .HasData(IceCreamOptions);
        }
    }
}
