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
    public class CustomerEditAction : IAction
    {

        private readonly CustomerRepository _customerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit customer";

        public CustomerEditAction(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            var customers = _customerRepository.GetAll();
            PrintHelpers.ShortPrintCustomers(customers);
            Console.WriteLine("\n Type customer Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var customerId);
            if (!isRead)
                return;

            var customer = customers.First(c => c.Id == customerId);

            Console.WriteLine("Press enter to skip edit");

            Console.WriteLine($"First Name: ({customer.FirstName})");
            customer.FirstName = ReadHelpers.TryReadLineIfNotEmpty(out var firstName)
                ? firstName
                : customer.FirstName;

            Console.WriteLine($"Last name: ({customer.LastName})");
            customer.LastName = ReadHelpers.TryReadLineIfNotEmpty(out var lastName)
                ? lastName
                : customer.LastName;

            Console.WriteLine($"Oib: ({customer.OIB})");
            customer.OIB = ReadHelpers.TryReadLineIfNotEmpty(out var oib)
                ? oib
                : customer.OIB;

            var response = _customerRepository.Edit(customer, customerId);

            if (response == ResponseResultType.Success)
            {
                PrintHelpers.PrintCustomer(customer);
            }

            if (response == ResponseResultType.NotFound)
            {
                Console.WriteLine("Customer not found");
            }

            if (response == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
