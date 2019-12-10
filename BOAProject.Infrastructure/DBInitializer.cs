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
                     new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-10285377_720x.png?v=1570240884"},
                     new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-e129077d_720x.png?v=1570240884"},
                     new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-2ade0e5d_720x.png?v=1570240884"},
                     new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-7e5f3a3f_590x.png?v=1570240884"},
                   
                    
                   
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
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-0b38880d_720x.png?v=1570240883"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-4e64433f_590x.png?v=1570240883"}
                    
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
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-2fb0b308_720x.jpg?v=1572523333"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-9dbde078_720x.jpg?v=1572523333"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-48d47526_720x.jpg?v=1572523329"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-c66ab291_590x.jpg?v=1572523333"}
                    
                   
                    
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
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-f4f4479d_720x.png?v=1574766123"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-905697b7_720x.png?v=1574766121"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-cc269368_720x.png?v=1574766119"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-a9605740_720x.png?v=1574766118"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-d68a14aa_590x.png?v=1574766115"}
                    
                    
                    
                    
                    
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
            var p7 = ctx.Products.Add(new Product()
            {
                Name = "Unisex Black BOA T-Shirt",
                SizeQuantity = sizes,
                Type = "T-Shirts",
                Collection = null,
                Price = 59.99,
                Gender = "Unisex",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/f86198d84a1dfa542db18a0ca8c74666_02a43c59-2dd8-44c5-88a0-5d5320975bfe_720x.jpg?v=1570240882"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/6afa822247494d4dc68db0cbc194c831_9288aabd-0315-4916-ba75-7643d0d72a08_720x.jpg?v=1570240882"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/8e48e477242ea3ea6ea934fc477ff527_d3c6ff42-27e1-44db-9803-f39cb29865cf_720x.jpg?v=1570240882"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/def750fccfcc20a8695e260b1ec937ac_06ba523d-3200-4c9a-81e6-d232febf09e6_590x.jpg?v=1570240882"}
                }
            }).Entity;
            var p8 = ctx.Products.Add(new Product()
            {
                Name = "Unisex White BOA T-Shirt",
                SizeQuantity = sizes,
                Type = "T-Shirts",
                Collection = null,
                Price = 59.99,
                Gender = "Unisex",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                     new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/f27458cf19a5e23a80afe358c911b867_af46f5b8-cebb-4120-8eea-69e1ffe19b2a_720x.jpg?v=1570240882"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/f27458cf19a5e23a80afe358c911b867_af46f5b8-cebb-4120-8eea-69e1ffe19b2a_720x.jpg?v=1570240882"}
                   
                }
            }).Entity;
            var p9 = ctx.Products.Add(new Product()
            {
                Name = "Crop Tee",
                SizeQuantity = sizes,
                Type = "Tops",
                Collection = null,
                Price = 54.99,
                Gender = "Women",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-a3766a19_720x.png?v=1570240881"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-df88789f_590x.png?v=1570240881"}
                }
            }).Entity;
            var p10 = ctx.Products.Add(new Product()
            {
                Name = "Baseball T-Shirt",
                SizeQuantity = sizes,
                Type = "T-Shirts",
                Collection = null,
                Price = 59.99,
                Gender = "Women",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-b11ec8ee_590x.jpg?v=1570240871"}
                }
            }).Entity;
            var p11 = ctx.Products.Add(new Product()
            {
                Name = "Ringer T-Shirt (Unisex)",
                SizeQuantity = sizes,
                Type = "T-Shrits",
                Collection = The6ixCollection,
                Price = 59.99,
                Gender = "Unisex",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-75e70111_590x.png?v=1570240879"}
                }
            }).Entity;
            var p12 = ctx.Products.Add(new Product()
            {
                Name = "Women's BOA Rose Crop Tee",
                SizeQuantity = sizes,
                Type = "Tops",
                Collection = TheRoseCollection,
                Price = 59.99,
                Gender = "Women",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-91a9de83_720x.png?v=1570240865"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-f1a84ce9_720x.png?v=1570240865"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-01d087cb_720x.png?v=1570240865"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-d881b9a6_590x.png?v=1570240865"}
                }
            }).Entity;
            var p13 = ctx.Products.Add(new Product()
            {
                Name = "Black Men's OG Lightweight BOA Hoodie",
                SizeQuantity = sizes,
                Type = "Hoodies And Sweatshirts",
                Collection = null,
                Price = 94.99,
                Gender = "Men",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/7af88916046d347a742621d24cff4685_fd35f3f9-b21e-46f3-8869-28d9848750d2_720x.jpg?v=1570240851"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/a4059ab4d21ca23f715c93e49ba5e0e4_0e1d1860-50e2-426b-abeb-f31f57274fa2_590x.jpg?v=1570240851"}
                }
            }).Entity;
            var p14 = ctx.Products.Add(new Product()
            {
                Name = "Navy Men's OG Lightweight BOA Hoodie",
                SizeQuantity = sizes,
                Type = "Hoodies And Sweatshirts",
                Collection = null,
                Price = 94.99,
                Gender = "Men",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/eac7ef5739afa7247b7739fada0499db_720x.jpg?v=1570240852"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/c827500003c6a8b416ce77defb32568d_7b79f147-7b33-4501-b20d-8b5926e9f99b_590x.jpg?v=1570240852"}
                }
            }).Entity;
            var p15 = ctx.Products.Add(new Product()
            {
                Name = "Charcoal Men's OG Lightweight BOA Hoodie",
                SizeQuantity = sizes,
                Type = "Hoodies And Sweatshirts",
                Collection = null,
                Price = 94.99,
                Gender = "Men",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/441656a772af5488e0735d1cc544cd5c_34f103b1-c583-44d3-95af-16ffcdbf50f4_720x.jpg?v=1570240854"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/4d33a64507f875eb4788798f68e2d414_e14ca839-dd32-420b-8921-f457f840d8d4_590x.jpg?v=1570240854"}
                }
            }).Entity;
            var p16 = ctx.Products.Add(new Product()
            {
                Name = "Garnet Men's OG Lightweight BOA Hoodie",
                SizeQuantity = sizes,
                Type = "Hoodies And Sweatshirts",
                Collection = null,
                Price = 94.99,
                Gender = "Men",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/fb610721be261c5f7107d12d0d8863f8_0f6428b0-103f-4bff-8d3c-49af741e884e_720x.jpg?v=1570240853"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/a5c57b0fe56385efd940b41c5c939259_8434bb5a-2fce-45e7-b554-9102bc2f44e7_590x.jpg?v=1570240853"}
                }
            }).Entity;
            var p17 = ctx.Products.Add(new Product()
            {
                Name = "Men's Sweatshirt",
                SizeQuantity = sizes,
                Type = "Hoodies And Sweatshirts",
                Collection = HalfInHalf,
                Price = 74.99,
                Gender = "Men",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-2fb0b308_720x.jpg?v=1572523333"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-9dbde078_720x.jpg?v=1572523333"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-48d47526_720x.jpg?v=1572523329"},
                    new Picture() { PictureLink = "https://cdn.shopify.com/s/files/1/2468/9609/products/mockup-c66ab291_590x.jpg?v=1572523333"}
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
