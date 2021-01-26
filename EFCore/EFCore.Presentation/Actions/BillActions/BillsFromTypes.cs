using EFCore.Data.Entities.Models;
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
    public class BillsFromTypes : IAction
    {
        private readonly BillRepository _billRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get bills from types ";
        public BillsFromTypes(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public void Call()
        {
            Console.WriteLine("Type in the type you want to get bills from: ");
            if (!ReadHelpers.TryReadLineIfNotEmpty(out var typeName))
            {
                Console.WriteLine("Wrong input");
                Console.ReadLine();
                return;
            }
            var bills = new List<Bill>();
            switch (typeName.ToLower())
            {
                case "service":
                    _billRepository.GetByType(Data.Enums.SaleType.Service);
                    break;
                case "items":
                    _billRepository.GetByType(Data.Enums.SaleType.Item);
                    break;
                case "subscriptions":
                    _billRepository.GetByType(Data.Enums.SaleType.Subscription);
                    break;
                default:
                    Console.WriteLine("wrong input");
                    break;
            }
            foreach (var bill in bills)
            {
                PrintHelpers.PrintBill(bill, _billRepository.GetPrice(bill.Id));
            }
            Console.ReadLine();
        }
    }
}
