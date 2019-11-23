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
                Name = "Mads fashion",
            }).Entity;

            Product p = new Product()
            {
                Name = "Dirty Mads",
                Size = Size.XL,
                Type = "T-Shirt",
                AvailableQuantity = 1,
                Collection = c,
                Price = 99,
                Gender = "Female",
                Description = "Low quality T-Shirt worn by renowned Mads Beier on his alcoholic marathon JKJK."
            };

            ctx.Add(p);
            ctx.SaveChanges();
        }
    }
}
