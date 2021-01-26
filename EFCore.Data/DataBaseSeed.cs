using EFCore.Data.Entities;
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
            builder.Entity<Employee>()
                .HasData(new List<Employee>
                {
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Mate",
                        LastName = "Matic",
                        StartOfShift = new DateTime(2020, 1, 1, 8, 0, 0),
                        EndOfShift = new DateTime(2020, 1, 1, 17, 0, 0),
                        Availability = true
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Ivan",
                        LastName = "Ivanovic",
                        StartOfShift = new DateTime(2020, 1, 1, 8, 0, 0),
                        EndOfShift = new DateTime(2020, 1, 1, 17, 0, 0),
                        Availability = true
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Jovan",
                        LastName = "Jovic",
                        StartOfShift = new DateTime(2020, 1, 1, 8, 0, 0),
                        EndOfShift = new DateTime(2020, 1, 1, 17, 0, 0),
                        Availability = true
                    }
                });
            builder.Entity<Offer>()
                .HasData(new List<Offer>
                {
                    new Offer
                    {
                        Id = 1,
                        Name = "Gitara",
                        Price = 500,
                        AmmountLeft = 30,
                        AmmountSold = 0,
                        Availability = true,
                        SaleType = Enums.SaleType.Item
                    },
                    new Offer
                    {
                        Id = 2,
                        Name = "Car Wash",
                        Price = 50,
                        AmmountLeft = 1000,
                        AmmountSold = 0,
                        Availability = true,
                        SaleType = Enums.SaleType.Service ,
                        EmployeeId = 1
                    },
                    new Offer
                    {
                        Id = 3,
                        Name = "Dog Food",
                        Price = 10,
                        AmmountLeft = 100,
                        AmmountSold = 0,
                        Availability = true,
                        SaleType = Enums.SaleType.Item
                    },
                    new Offer
                    {
                        Id = 4,
                        Name = "White t-shirt",
                        Price = 30,
                        AmmountLeft = 50,
                        AmmountSold = 0,
                        Availability = true,
                        SaleType = Enums.SaleType.Item ,
                    },
                    new Offer
                    {
                        Id = 5,
                        Name = "Monthly Repairs",
                        Price = 100,
                        AmmountLeft = 10000000,
                        AmmountSold = 0,
                        Availability = true,
                        SaleType = Enums.SaleType.Subscription
                    }
                }
                );
        }
    }
}
