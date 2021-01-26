using EFCore.Data.Entities.Models;
using EFCore.Domain.Enums;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.CustomerActions
{
    public class CustomerAddAction : IAction
    {
        private readonly CustomerRepository _customerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add customer";

        public CustomerAddAction(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            var customer = new Customer();

            Console.WriteLine("First name:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("LastName:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("OIB:");
            customer.OIB = Console.ReadLine();

            var responseResult = _customerRepository.Add(customer);

            if (responseResult == ResponseResultType.Success)
            {
                PrintHelpers.PrintCustomer(customer);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Failed to save customer, no changes applied");
            Console.ReadLine();
        }
    }
}
