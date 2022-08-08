using EShopper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new DataContext();

            if (context.Database.GetPendingMigrations().Count() == 0) // Uygulanmamış Migrations Var Mı?
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);
                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories =
        {
            new Category(){Name="Telefon"},
            new Category(){Name="Bilgisayar"},
            new Category(){Name="Elektronik"}
        };

        private static Product[] Products =
        {
               new Product(){Name="IPhone X10", ImageUrl="1.jpg",    Price=10000,Description="<p>Güzel Telefon</p>"},
               new Product(){Name="Samsung Note10", ImageUrl="2.jpg",Price=14000,Description="<p>Güzel Telefon</p>"},
               new Product(){Name="Samsung Note11", ImageUrl="3.jpg",Price=20000,Description="<p>Güzel Telefon</p>"},
               new Product(){Name="IPhone 11S", ImageUrl="4.jpg",    Price=15000,Description="<p>Güzel Telefon</p>"},
               new Product(){Name="IPhone 12S", ImageUrl="4.jpg",    Price=15000,Description="<p>Güzel Telefon</p>"},
               new Product(){Name="IPhone 13S", ImageUrl="4.jpg",    Price=15000,Description="<p>Güzel Telefon</p>"},
               new Product(){Name="IPhone 14S", ImageUrl="4.jpg",    Price=15000,Description="<p>Güzel Telefon</p>"}
        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[0],Category=Categories[2]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[1]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]}
        };
    }
}
