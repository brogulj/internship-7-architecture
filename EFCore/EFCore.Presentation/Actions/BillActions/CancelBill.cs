using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.BillActions
{
    public class CancelBill : IAction
    {
        private readonly BillRepository _billRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; }
        public CancelBill(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public void Call()
        {
            foreach (var bill in _billRepository.GetAll())
            {
                PrintHelpers.PrintBill(bill, _billRepository.GetPrice(bill.Id));
            }

            Console.WriteLine("Enter the ID of the bill you want to cancel: ");
            if (!ReadHelpers.TryReadNumber(out var billId))
            {
                Console.WriteLine("Error with bill ID input");
                Console.ReadLine();
                return;
            }

            if (_billRepository.CancelById(billId) == Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("Bill successfully canceled");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Bill not canceled");
            Console.ReadLine();
        }
    }
}
