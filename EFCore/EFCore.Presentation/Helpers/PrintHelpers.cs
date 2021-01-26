using System;
using System.Collections.Generic;
using EFCore.Data.Entities.Models;

namespace EFCore.Presentation.Helpers
{
    public static class PrintHelpers
    {
        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine("======CUSTOMER======");
            Console.WriteLine($"Customer ID: {customer.Id}");
            Console.WriteLine($"First name: {customer.FirstName}");
            Console.WriteLine($"Last name: {customer.LastName}");
            Console.WriteLine($"OIB: {customer.OIB}");
        }

        public static void ShortPrintCustomer(Customer customer)
        {
            Console.WriteLine($"Id: {customer.Id} \t First Name: {customer.FirstName} \t Last Name: {customer.LastName} \t OIB: {customer.OIB}");
        }
        public static void ShortPrintCustomers(ICollection<Customer> customers)
        {
            foreach (var customer in customers)
            {
                ShortPrintCustomer(customer);
            }
        }

        public static void ShortPrintEmployee(Employee employee)
        {
            Console.WriteLine($"Employee ID: {employee.Id}, First Name: {employee.FirstName}, Last Name {employee.LastName}");
        }

        public static void PrintOffer(Offer offer)
        {

            Console.WriteLine("=====OFFER=====");
            Console.WriteLine($"ID: {offer.Id}");
            Console.WriteLine($"Name: {offer.Name}");
            Console.WriteLine($"Ammount Sold: {offer.AmmountSold}");
            Console.WriteLine($"Ammount Left: {offer.AmmountLeft}");
            Console.WriteLine($"Availability: {offer.Availability}");
            switch (offer.SaleType)
            {
                case Data.Enums.SaleType.Service:
                    ShortPrintEmployee(offer.Employee);
                    Console.WriteLine($"Price per hour: {offer.Price}$");
                    break;
                case Data.Enums.SaleType.Item:
                    Console.WriteLine($"Price per piece: {offer.Price}$");
                    break;
                case Data.Enums.SaleType.Subscription:
                    Console.WriteLine($"Price per month: {offer.Price}$");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Categories: ");
            foreach (var category in offer.Categories)
            {
                Console.WriteLine($"           {category.Name}");
            }

        }
        public static void PrintSale(Sale sale)
        {
            Console.WriteLine("=====SALE=====");
            Console.WriteLine($"ID: {sale.Id}");
            Console.WriteLine($"Sale Date: {sale.SaleDate}");
            Console.WriteLine($"Ammount: {sale.Ammount}");
            Console.WriteLine($"Validity: {sale.Validity}");
            Console.WriteLine($"Sale type: {sale.SaleType}");
            switch (sale.SaleType)
            {
                case Data.Enums.SaleType.Service:
                    Console.WriteLine($"Start Time: {sale.StartTime}");
                    Console.WriteLine($"End Time: {sale.EndTime}");
                    Console.WriteLine($"Price: {sale.Offer.Price*sale.Ammount}");
                    PrintHelpers.ShortPrintEmployee(sale.Offer.Employee);
                    break;
                case Data.Enums.SaleType.Item:
                    Console.WriteLine($"Price: {sale.Offer.Price * sale.Ammount}");
                    break;
                case Data.Enums.SaleType.Subscription:
                    Console.WriteLine($"Start Time: {sale.StartTime}");
                    Console.WriteLine($"End Time: {sale.EndTime}");
                    Console.WriteLine($"Price: {sale.Offer.Price * sale.Ammount}");
                    break;
                default:
                    break;
            }
        }
        public static void PrintBill(Bill bill, int price)
        {
            
            Console.WriteLine("=====BILL ID=====");
            foreach (var sale in bill.Sales)
            {
                PrintSale(sale);
            }
            Console.WriteLine($"TOTAL PRICE: {price}");
        }
    }
}
