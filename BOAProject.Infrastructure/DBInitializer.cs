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


            var p = ctx.Products.Add(new Product()
            {
                Name = "Constrictor T-Shirt",
                SizeQuantity = defineSizes(10,10,10,10,10,10,1),
                Type = "T-Shirts",
                Collection = The6ixCollection,
                Price = 59.99,
                Gender = "Men",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures =  new List<Picture>() {
                     new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85071053_1620447228079522_2005585513452404736_n.png?_nc_cat=106&_nc_ohc=Ii9rZrA9E8UAX_wDlmm&_nc_ht=scontent.fzgh1-1.fna&oh=a8554a1a09ef848f31d48c36ec03ae35&oe=5ED281A0"},
                     new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84415209_190626818963887_3852348625266933760_n.png?_nc_cat=106&_nc_ohc=V27_-d4_shcAX9Vhijz&_nc_ht=scontent.fzgh1-1.fna&oh=f6031ff40d20be4dd438e257d730c38f&oe=5ED29A9F"},
                     new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84569812_569488843780582_4766417450830921728_n.png?_nc_cat=106&_nc_ohc=xfLhHcjbu-8AX9C-DQP&_nc_ht=scontent.fzgh1-1.fna&oh=9944f7c957b9d3225dd7e6eaa8f0a44e&oe=5EB5945F"},
                     new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85058225_768672516973483_5435794426104381440_n.png?_nc_cat=107&_nc_ohc=he5F3Eowo28AX8pGf4c&_nc_ht=scontent.fzgh1-1.fna&oh=b3c2ac66280e71d318c371db44d05dad&oe=5EB6B3EC"},
                   
                    
                   
                }
            }).Entity;
            var p2 = ctx.Products.Add(new Product()
            {
                Name = "Constrictor Crop Top",
                SizeQuantity = defineSizes(10, 10, 10, 10, 10, 10,1),
                Type = "Tops",
                Collection = The6ixCollection,
                Price = 54.99,
                Gender = "Women",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84717172_1046498499063324_2931976037547900928_n.png?_nc_cat=110&_nc_ohc=jf1HP8Y_lHcAX8O2R41&_nc_ht=scontent.fzgh1-1.fna&oh=537a3b5b1fbc5e8e0aa65ed54b137e4a&oe=5ED76ED5"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85077497_803064943544268_6293257287809105920_n.png?_nc_cat=109&_nc_ohc=WYZizU05qocAX8o25IR&_nc_ht=scontent.fzgh1-1.fna&oh=92dc973f06a17096432fc21811fc0994&oe=5EB9AB78"}
                    
                }

            }).Entity;
            var p3 = ctx.Products.Add(new Product()
            {
                Name = "Men's Sweatshirt",
                SizeQuantity = defineSizes(10, 10, 10, 10, 10, 10,2),
                Type = "Hoodies And Sweatshirts",
                Collection = TheRoseCollection,
                Price = 299,
                Gender = "Men",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85090375_218347195870529_6827110006031122432_n.png?_nc_cat=109&_nc_ohc=kIDV97HbTeAAX_lDlUN&_nc_ht=scontent.fzgh1-1.fna&oh=a8ce133236eea7ee2d4fb32bbf2514e8&oe=5EC5BFA7"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84584392_3224876687540673_2397101434937016320_n.png?_nc_cat=100&_nc_ohc=B3mcLPZs2gEAX-LxaCi&_nc_ht=scontent.fzgh1-1.fna&oh=89e3df6a1fca1bab399ec8aa611defc4&oe=5EB707FD"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84817778_619238498863719_729875059971194880_n.png?_nc_cat=106&_nc_ohc=KhbpIw7IarEAX-Inv9y&_nc_ht=scontent.fzgh1-1.fna&oh=1dcc5c398ef407c0a3e799aeedbeaacf&oe=5ED79496"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85183440_2891982967489701_4863323831562928128_n.png?_nc_cat=103&_nc_ohc=BthLSmQY3PoAX-XSY1t&_nc_ht=scontent.fzgh1-1.fna&oh=65ce42c4d9183cd3a0963b7b7242da52&oe=5EBA8C0E"}
                    
                   
                    
                }
            }).Entity;
            var p4 = ctx.Products.Add(new Product()
            {
                Name = "Packable Jacket",
                SizeQuantity = defineSizes(10, 10, 10, 10, 10, 10, 5),
                Type = "no type",
                Collection = BOAChampion,
                Price = 109.99,
                Gender = "Unisex",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85068376_1532136173604085_2685777448305426432_n.png?_nc_cat=105&_nc_ohc=6AwGGWCwchwAX_BCVEZ&_nc_ht=scontent.fzgh1-1.fna&oh=9027bd13a557223b22bf02073658163a&oe=5ECB7AD4"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84596196_138486450625194_2747144662585180160_n.png?_nc_cat=104&_nc_ohc=PuBinsXCNDAAX-AhJeA&_nc_ht=scontent.fzgh1-1.fna&oh=2a533c97b6a6cdbde86f0edc5a861a07&oe=5ED43421"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84661099_124349688914718_8479237255964131328_n.png?_nc_cat=103&_nc_ohc=8IWZ-nvATzAAX_7SEYg&_nc_ht=scontent.fzgh1-1.fna&oh=3c9bb3889e96f4e5d35f166304e21645&oe=5EB8549B"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85085728_632281924262059_9011626507029708800_n.png?_nc_cat=110&_nc_ohc=nKDo44ZguHEAX8awFXm&_nc_ht=scontent.fzgh1-1.fna&oh=80b251d2aea9a1f2b9f1a4feeeb2f2c1&oe=5ED3B57A"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84491697_1041893282857688_1159206416150429696_n.png?_nc_cat=106&_nc_ohc=38SJH7kDbVsAX_R998e&_nc_ht=scontent.fzgh1-1.fna&oh=ad0c6adec86d2e661a6bd729d199a94c&oe=5ECE6D06"}
                    
                    
                    
                    
                    
                }
            }).Entity;
            var p5 = ctx.Products.Add(new Product()
            {
                Name = "White Snake Slit Fitted Mini Skirt",
                SizeQuantity = defineSizes(10, 10, 10, 10, 10, 10, 6),
                Type = "Dresses And Skirts",
                Collection = null,
                Price = 59.99,
                Gender = "Women",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85230647_259555445012649_2544518018344419328_n.png?_nc_cat=108&_nc_ohc=7AlTZLzpbDUAX9nM3ZT&_nc_ht=scontent.fzgh1-1.fna&oh=906ad8d0a3ad29b17985080a0391aef7&oe=5ED7202D"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85002466_492738878105978_8471512229001297920_n.png?_nc_cat=105&_nc_ohc=X3KcDugOKc0AX9nrSWA&_nc_ht=scontent.fzgh1-1.fna&oh=4212ade6b8899d7701c1479586e0a007&oe=5EBD3BAB"}

                }
            }).Entity;
            var p6 = ctx.Products.Add(new Product()
            {
                Name = "Crop Tee",
                SizeQuantity = defineSizes(10, 10, 10, 10, 10, 10, 0),
                Type = "Tops",
                Collection = HalfInHalf,
                Price = 59.99,
                Gender = "Women",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84669745_1573810892784544_8416175303423950848_n.png?_nc_cat=102&_nc_ohc=H9IrEd04ygYAX-ONKrf&_nc_ht=scontent.fzgh1-1.fna&oh=7423c0ba059063153ab3ee368e2cb110&oe=5ED20013"}

                }
            }).Entity;
            var p7 = ctx.Products.Add(new Product()
            {
                Name = "Unisex Black BOA T-Shirt",
                SizeQuantity = defineSizes(0, 10, 105, 10, 10, 10, 0),
                Type = "T-Shirts",
                Collection = null,
                Price = 59.99,
                Gender = "Unisex",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84860611_619976168766491_1769015124196065280_n.png?_nc_cat=106&_nc_ohc=LEr3nMHgtlAAX81vOfd&_nc_ht=scontent.fzgh1-1.fna&oh=ac07ecb38dc2958a4ddb5834d903f336&oe=5EC7D65F"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85112711_2383445045281066_1978800422357303296_n.png?_nc_cat=100&_nc_ohc=BZp4QXWNW6sAX_Jm7_m&_nc_ht=scontent.fzgh1-1.fna&oh=b76f864801d2568ec961d601bd86b712&oe=5EBE52B0"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85112009_295482351412494_1875157016054333440_n.png?_nc_cat=104&_nc_ohc=JRz1HxwWTJUAX-Cr5S3&_nc_ht=scontent.fzgh1-1.fna&oh=2ef83456f1b4339e2e227c20f21a955c&oe=5EBF163E"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85087530_497855001133878_3530306316645957632_n.png?_nc_cat=103&_nc_ohc=aEFYBQ4IdmEAX8A-nCg&_nc_ht=scontent.fzgh1-1.fna&oh=03640310dbe0695f4c229bfd1747c60b&oe=5ED689CF"}
                }
            }).Entity;
            var p8 = ctx.Products.Add(new Product()
            {
                Name = "Unisex White BOA T-Shirt",
                SizeQuantity = defineSizes(1, 1, 1, 16, 10, 10, 8),
                Type = "T-Shirts",
                Collection = null,
                Price = 59.99,
                Gender = "Unisex",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                     new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84947044_1629464167191857_8814984040722464768_n.png?_nc_cat=107&_nc_ohc=v0F3ufWFc4wAX_atyFb&_nc_ht=scontent.fzgh1-1.fna&oh=c28adc9ffeebfefede99e032dc833a4c&oe=5EC10D6D"}
                   
                }
            }).Entity;
            var p9 = ctx.Products.Add(new Product()
            {
                Name = "Crop Tee",
                SizeQuantity = defineSizes(10, 40, 5, 7, 0, 9, 1),
                Type = "Tops",
                Collection = null,
                Price = 54.99,
                Gender = "Women",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84727561_624183371710786_5575213724572057600_n.png?_nc_cat=111&_nc_ohc=MBVCOjSVHGIAX_UqFwm&_nc_ht=scontent.fzgh1-1.fna&oh=1b09cd545ff972d2b75a777271db9220&oe=5ECC3240"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85095813_586742282174964_3708313121719320576_n.png?_nc_cat=105&_nc_ohc=poBAT9TESNMAX9AQGMv&_nc_ht=scontent.fzgh1-1.fna&oh=97d5c8621725b12b0fa001b5463c6bca&oe=5ECA5C14"}
                }
            }).Entity;
            var p10 = ctx.Products.Add(new Product()
            {
                Name = "Baseball T-Shirt",
                SizeQuantity = defineSizes(0, 0, 0, 10, 0, 10, 4),
                Type = "T-Shirts",
                Collection = null,
                Price = 59.99,
                Gender = "Women",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84954506_327926675114507_7536199919665676288_n.png?_nc_cat=110&_nc_ohc=d1_lk4pXrYMAX_ALNMS&_nc_ht=scontent.fzgh1-1.fna&oh=7964c828326ed5e9f52453e24993ad47&oe=5EC882F2"}
                }
            }).Entity;
            var p11 = ctx.Products.Add(new Product()
            {
                Name = "Ringer T-Shirt (Unisex)",
                SizeQuantity = defineSizes(1, 1, 1, 1, 1, 1, 5),
                Type = "T-Shrits",
                Collection = The6ixCollection,
                Price = 59.99,
                Gender = "Unisex",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85042234_905529826533166_2190991189967110144_n.png?_nc_cat=104&_nc_ohc=X7IlW8aoyGIAX_vEiED&_nc_ht=scontent.fzgh1-1.fna&oh=bc71892f70bdc516a73842221f6347a4&oe=5EB5056B"}
                }
            }).Entity;
            var p12 = ctx.Products.Add(new Product()
            {
                Name = "Women's BOA Rose Crop Tee",
                SizeQuantity = defineSizes(0, 10, 100, 100, 10, 100, 4),
                Type = "Tops",
                Collection = TheRoseCollection,
                Price = 59.99,
                Gender = "Women",
                Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit" +
          "quo minus id quod maxime placeat facere possimus," +
                "omnis voluptas assumenda est," +
                "omnis dolor repellendus" +
          "et aut officiis cum soluta nobis est eligendi placeat facere aut rerum.",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84923162_178508176756758_996715352232558592_n.png?_nc_cat=111&_nc_ohc=D3FEqxR-nKoAX_JcCut&_nc_ht=scontent.fzgh1-1.fna&oh=0337e05b63a30596fe1983eccbf46142&oe=5EB90B91"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84491994_118920959537962_3031848333715963904_n.png?_nc_cat=108&_nc_ohc=eT9_KjZy_YwAX--O8Ju&_nc_ht=scontent.fzgh1-1.fna&oh=68f6cfa8092f89b6367324a6ce62d71b&oe=5ECBBE78"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84631007_206133303901347_8633030590200807424_n.png?_nc_cat=106&_nc_ohc=l_ZRa3zDbrIAX-ENfzM&_nc_ht=scontent.fzgh1-1.fna&oh=6a4dad94055b7c37c64968d691dff6c7&oe=5ECD51DF"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85165297_192034088839592_3223246086609043456_n.png?_nc_cat=100&_nc_ohc=GoMd3r1ZM1cAX9R9Nym&_nc_ht=scontent.fzgh1-1.fna&oh=2755ff5cdf89719a29dd8697908f1f2c&oe=5F013874"}
                }
            }).Entity;
            
          
          
           
            var p17 = ctx.Products.Add(new Product()
            {
                Name = "Men's Sweatshirt",
                SizeQuantity = defineSizes(10, 10, 10, 10, 10, 10, 4),
                Type = "Hoodies And Sweatshirts",
                Collection = HalfInHalf,
                Price = 74.99,
                Gender = "Men",
                Description = "to be later edited",
                Pictures = new List<Picture>() {
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85090375_218347195870529_6827110006031122432_n.png?_nc_cat=109&_nc_ohc=kIDV97HbTeAAX_lDlUN&_nc_ht=scontent.fzgh1-1.fna&oh=a8ce133236eea7ee2d4fb32bbf2514e8&oe=5EC5BFA7"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/84817778_619238498863719_729875059971194880_n.png?_nc_cat=106&_nc_ohc=KhbpIw7IarEAX-Inv9y&_nc_ht=scontent.fzgh1-1.fna&oh=1dcc5c398ef407c0a3e799aeedbeaacf&oe=5ED79496"},
                    new Picture() { PictureLink = "https://scontent.fzgh1-1.fna.fbcdn.net/v/t1.15752-9/85183440_2891982967489701_4863323831562928128_n.png?_nc_cat=103&_nc_ohc=BthLSmQY3PoAX-XSY1t&_nc_ht=scontent.fzgh1-1.fna&oh=65ce42c4d9183cd3a0963b7b7242da52&oe=5EBA8C0E"}
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
            string password2 = "5678";
            byte[] passwordHash2, passwordSalt2;
            authHelp.CreatePasswordHash(password2, out passwordHash2, out passwordSalt2);
            var user2 = ctx.Users.Add(new User()
            {
                Email = "mrhandsome@gmail.com",
                PasswordHash = passwordHash2,
                PasswordSalt = passwordSalt2,
                LastActive = DateTime.Now,
                IsAdmin = false

            }).Entity;
            var userList = new List<User>() { user, user2 };

            var address = ctx.Addresses.Add(new Address()
            {
                Street = "Danmarksgade 68",
                City = "Esbjerg",
                Country = "Denmark",
                ZipCode = "6700",
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

        public List<SizeQuantity> defineSizes(int XS, int S , int M, int L,  int XL, int XXL , int XXXL)
        {
            return new List<SizeQuantity>()
            {
              new SizeQuantity(Size.XS,XS),
              new SizeQuantity(Size.S,S),
              new SizeQuantity(Size.M,M),
              new SizeQuantity(Size.L,L),
              new SizeQuantity(Size.XL,XL),
              new SizeQuantity(Size.XXL,XXL),
              new SizeQuantity(Size.XXXL,XXXL),
            };
        }
    }
}
