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
                Name = "The 6ix"
            }).Entity;
            var BOAChampion = ctx.Collections.Add(new Collection()
            {
                Name = "BOA x Champion"
            }).Entity;
            var TheRoseCollection = ctx.Collections.Add(new Collection()
            {
                Name = "The Rose"
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
                Type = "T-Shirts",
                Collection = The6ixCollection,
                Price = 59.99,
                Gender = "Men",
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
            var p2 = ctx.Products.Add(new Product()
            {
                Name = "Constrictor Crop Top",
                SizeQuantity = sizes,
                Type = "Tops",
                Collection = The6ixCollection,
                Price = 54.99,
                Gender = "Women",
                Description = "A fitted crop top to pair with skirts, jeans, and much more. Made of 100% cotton, this crop top has a soft hand feel and light texture."+
                "\n• 100 % 30 / 1 combed cotton" +
                "\n• Form fitting" +
                "\n• Made in the USA" +
                "\n• Two colors: black and white" +
                "\n• Bottom hem has an unfinished, raw edge",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-4e64433f_590x.png?v=1570240883"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-0b38880d_720x.png?v=1570240883"}
                }

            }).Entity;
            var p3 = ctx.Products.Add(new Product()
            {
                Name = "Men's Sweatshirt",
                SizeQuantity = sizes,
                Type = "Hoodies And Sweatshirts",
                Collection = TheRoseCollection,
                Price = 299,
                Gender = "Men",
                Description = "• 70% polyester, 27% cotton, 3% elastane" +
                "• Soft cotton - feel face" +
                "• Brushed fleece fabric inside" +
                "• Unisex style" +
                "• Overlock seams",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-c66ab291_590x.jpg?v=1572523333"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-48d47526_720x.jpg?v=1572523329"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-9dbde078_720x.jpg?v=1572523333"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-2fb0b308_720x.jpg?v=1572523333"}
                }
            }).Entity;
            var p4 = ctx.Products.Add(new Product()
            {
                Name = "Packable Jacket",
                SizeQuantity = sizes,
                Type = "no type",
                Collection = BOAChampion,
                Price = 109.99,
                Gender = "Unisex",
                Description = "(Unisex) Protect yourself from the elements with this BOA x Champion packable jacket."+
                "This wind and rain resistant polyester jacket with a detailed embroidery design has a practical hood,"+
                "front kangaroo pocket, and zipped pouch pocket which you can pull out and use to scrunch the jacket into for convenient storage."+
                    "• 100 % polyester micro poplin"+
                    "• Wind and rain resistant"+
                    "• Half zip pullover with a hood"+
                    "• Front kangaroo pocket"+
                    "• Hidden zipped pouch pocket"+
                    "• Packable in the zipped pouch pocket"+
                    "• Adjustable bungee draw cord at hood and bottom hem"+
                    "• Elastic cuffs,",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-d68a14aa_590x.png?v=1574766115"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-a9605740_720x.png?v=1574766118"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-cc269368_720x.png?v=1574766119"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-905697b7_720x.png?v=1574766121"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-f4f4479d_720x.png?v=1574766123"}
                    
                }
            }).Entity;
            var p5 = ctx.Products.Add(new Product()
            {
                Name = "White Snake Slit Fitted Mini Skirt",
                SizeQuantity = sizes,
                Type = "Dresses And Skirts",
                Collection = null,
                Price = 59.99,
                Gender = "Women",
                Description = "(Unisex) Protect yourself from the elements with this BOA x Champion packable jacket." +
                "This wind and rain resistant polyester jacket with a detailed embroidery design has a practical hood," +
                "front kangaroo pocket, and zipped pouch pocket which you can pull out and use to scrunch the jacket into for convenient storage." +
                    "• 100 % polyester micro poplin" +
                    "• Wind and rain resistant" +
                    "• Half zip pullover with a hood" +
                    "• Front kangaroo pocket" +
                    "• Hidden zipped pouch pocket" +
                    "• Packable in the zipped pouch pocket" +
                    "• Adjustable bungee draw cord at hood and bottom hem" +
                    "• Elastic cuffs,",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-592f2ec9_590x.jpg?v=1570240845"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-6efba442_720x.jpg?v=1570240845"}

                }
            }).Entity;
            var p6 = ctx.Products.Add(new Product()
            {
                Name = "Crop Tee",
                SizeQuantity = sizes,
                Type = "Tops",
                Collection = HalfInHalf,
                Price = 59.99,
                Gender = "Women",
                Description =     "• 96% polyester, 4% elastane" +
                    "• Premium knit mid-weight jersey" +
                    "• Four-way stretch fabric that stretches and recovers on the cross and lengthwise grains" +
                    "• Regular fit",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-3bce8ee5_590x.png?v=1572522791"}

                }
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
