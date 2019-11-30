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


            //Adding all collections
            var The6ixCollection = ctx.Collections.Add(new Collection()
            {
                Name = "The 6ix Collection"
            }).Entity;
            var BOAChampion = ctx.Collections.Add(new Collection()
            {
                Name = "BOA x Champion"
            }).Entity;
            var TheRoseCollection = ctx.Collections.Add(new Collection()
            {
                Name = "The Rose Collection"
            }).Entity;
            var HalfInHalf = ctx.Collections.Add(new Collection()
            {
                Name = "Half In Half"
            }).Entity;

            var sizes = new List<SizeQuantity>() {
            new SizeQuantity(Size.L,10),
            new SizeQuantity(Size.M,160),
            new SizeQuantity(Size.S,490),
            new SizeQuantity(Size.XL,240),
            new SizeQuantity(Size.XXL,10)
            };

            var p = ctx.Products.Add(new Product()
            {
                Name = "Constrictor T-Shirt",
                SizeQuantity = sizes,
                Type = "T-Shirt",
                Collection = The6ixCollection,
                Price = 59.99,
                Gender = "Male",
                Description = "The tri-blend fabric creates a vintage, fitted look. And extreme durability makes this t-shirt withstand repeated washings and still remain super comfortable.\n"+
               "\n• Tri - blend construction(50 % polyester / 25 % combed ring - spun cotton / 25 % rayon)" +
               "\n• 40 singles thread weight" +
               "\n• Comfortable and durable" +
               "\n• Contemporary fit" +
               "\n• Lightweight",
                Pictures =  new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-7e5f3a3f_590x.png?v=1570240884"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-2ade0e5d_720x.png?v=1570240884"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-e129077d_720x.png?v=1570240884"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-10285377_720x.png?v=1570240884"},
                }
            }).Entity;

            var sizes2 = new List<SizeQuantity>() {
            new SizeQuantity(Size.L,30),
            new SizeQuantity(Size.M,330),
            new SizeQuantity(Size.S,305),
            new SizeQuantity(Size.XL,50),
            new SizeQuantity(Size.XXL,0)
            };
            var p2 = ctx.Products.Add(new Product()
            {
                Name = "Constrictor Crop Top",
                SizeQuantity = sizes2,
                Type = "Top",
                Collection = The6ixCollection,
                Price = 54.99,
                Gender = "Female",
                Description = "A fitted crop top to pair with skirts, jeans, and much more. Made of 100% cotton, this crop top has a soft hand feel and light texture."+
                "\n• 100 % 30 / 1 combed cotton" +
                "\n• Form fitting" +
                "\n• Made in the USA" +
                "\n• Two colors: black and white" +
                "\n• Bottom hem has an unfinished, raw edge"
            }).Entity;
            var sizes3 = new List<SizeQuantity>() {
            new SizeQuantity(Size.L,0),
            new SizeQuantity(Size.M,370),
            new SizeQuantity(Size.S,390),
            new SizeQuantity(Size.XL,30),
            new SizeQuantity(Size.XXL,60)
            };
            var p3 = ctx.Products.Add(new Product()
            {
                Name = "Mads in tha hood",
                //SizeQuantity = dictionary,
                Type = "Hoodie",
                Collection = TheRoseCollection,
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
                ProductQuantity = new List<ProductQuantity>() { productquantity },
                Total = p.Price,
                Address = address,
                User = user
            });


            
            ctx.SaveChanges();
        }
    }
}
