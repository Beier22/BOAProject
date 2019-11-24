using BOAProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Infrastructure
{
    public static class DBInitializer
    {
        public static void Seed(BOAShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var c = ctx.Collections.Add(new Collection()
            {
                Name = "Mads fashion"
            }).Entity;

            var p = ctx.Products.Add(new Product()
            {
                Name = "Dirty Mads",
                Size = Size.XL,
                Type = "T-Shirt",
                AvailableQuantity = 1,
                Collection = c,
                Price = 99,
                Gender = "Female",
                Description = "Low quality T-Shirt worn by renowned Mads Beier on his alcoholic marathon JKJK."
            }).Entity;
            var p2 = ctx.Products.Add(new Product()
            {
                Name = "Clean Mads",
                Size = Size.XL,
                Type = "Hoodie",
                AvailableQuantity = 5,
                Collection = c,
                Price = 159,
                Gender = "Female",
                Description = "Lately washed hoodie."
            }).Entity;
            var p3 = ctx.Products.Add(new Product()
            {
                Name = "Mads in tha hood",
                Size = Size.XXL,
                Type = "Hoodie",
                AvailableQuantity = 15,
                Collection = c,
                Price = 299,
                Gender = "Male",
                Description = "Perfect fit if you want to find gangsta dudes like Mads."
            }).Entity;

            var user = ctx.Users.Add(new User()
            {
                Email = "mbeier@gmail.com",
                PasswordHash = "password",
                PasswordSalt = "salty",
                LastActive = DateTime.Now,

            }).Entity;
            var userList = new List<User>() { user };

            var address = ctx.Addresses.Add(new Address()
            {
                Street = "Street",
                City = "City",
                Country = "Country",
                ZipCode = "zipcode",
                Users = userList
            }).Entity;

            var order = ctx.Orders.Add(new Order()
            {
                Products = new List<Product>() { p },
                Total = p.Price,
                Address = address,
                User = user
            });


            
            ctx.SaveChanges();
        }
    }
}
