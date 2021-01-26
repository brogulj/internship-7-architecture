using EFCore.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public class DataBaseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(new List<Category>
                {
                    new Category
                    {
                        Id =  1,
                        Name = "Building",
                    },

                    new Category
                    {
                        Id =  2,
                        Name = "Clothing",
                    },

                    new Category
                    {
                        Id =  3,
                        Name = "Food",
                    },

                    new Category
                    {
                        Id =  4,
                        Name = "Vehicles",
                    },

                    new Category
                    {
                        Id =  5,
                        Name = "Music",
                    },
                    new Category
                    {
                        Id =  6,
                        Name = "Pets",
                    }
                }
                );
            builder.Entity<Customer>()
                .HasData(new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Marko",
                        LastName = "Markic",
                        OIB = "12345"
                    },


                    new Customer
                    {
                        Id = 2,
                        FirstName = "Mirko",
                        LastName = "Mirkic",
                        OIB = "54321"
                    },


                    new Customer
                    {
                        Id = 3,
                        FirstName = "Sune",
                        LastName = "Sunic",
                        OIB = "76543"
                    }

                });
        }
    }
}
