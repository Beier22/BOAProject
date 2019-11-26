using BOAProject.Core.Entity;
using BOAProject.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Infrastructure
{
    public  class DBInitializer
    {
        private readonly IAuthenticationHelper authHelp;

        public DBInitializer(IAuthenticationHelper authenticationHelper)
        {
            authHelp = authenticationHelper;
        }

        public void Seed(BOAShopContext ctx)
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

            string password = "1234";
            byte[] passwordHash, passwordSalt;
            authHelp.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = ctx.Users.Add(new User()
            {
                Email = "mbeier@gmail.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                LastActive = DateTime.Now,
                IsAdmin = true

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

            var productquantity =  ctx.ProductsQuantities.Add(new ProductQuantity() { Product = p, Quantity = 1 }).Entity;

            var order = ctx.Orders.Add(new Order()
            {
                Products = new List<ProductQuantity>() { productquantity },
                Total = p.Price,
                Address = address,
                User = user
            });


            
            ctx.SaveChanges();
        }
    }
}
