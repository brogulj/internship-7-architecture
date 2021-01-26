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
    public class CustomerDeleteAction : IAction
    {
        private readonly CustomerRepository _customerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Customer";

        public CustomerDeleteAction(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            var customers = _customerRepository.GetAll();
            PrintHelpers.ShortPrintCustomers(customers);
            Console.WriteLine("Type in customer Id or exit");
            var isRead = ReadHelpers.TryReadNumber(out var customerId);
            if (!isRead) return;

            var response = _customerRepository.Delete(customerId);

            if (response == ResponseResultType.Success)
            {
                Console.WriteLine("Customer successfully deleted");
            }

            if (response == ResponseResultType.NoChanges)
            {
                Console.WriteLine("No changes applied");
            }

            if (response == ResponseResultType.NotFound)
            {
                Console.WriteLine("Customer does not exist");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
