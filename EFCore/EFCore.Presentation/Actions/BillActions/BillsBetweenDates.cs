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
    public class BillsBetweenDates : IAction
    {
        private readonly BillRepository _billRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get bill between dates";
        public BillsBetweenDates(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public void Call()
        {

            Console.WriteLine("Type first date day");
            ReadHelpers.TryReadNumber(out int firstDateDay);
            Console.WriteLine("Type first date month");
            ReadHelpers.TryReadNumber(out int firstDateMonth);
            Console.WriteLine("Type first date year");
            ReadHelpers.TryReadNumber(out int firstDateYear);
            if (!DateTime.TryParse($"{firstDateDay}/{firstDateMonth}/{firstDateYear}", out var firstDate))
            {
                Console.WriteLine("Wrong date format");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Type second date day");
            ReadHelpers.TryReadNumber(out int secondDateDay);
            Console.WriteLine("Type second date month");
            ReadHelpers.TryReadNumber(out int secondDateMonth);
            Console.WriteLine("Type second date year");
            ReadHelpers.TryReadNumber(out int secondDateYear);
            if (!DateTime.TryParse($"{secondDateDay}/{secondDateMonth}/{secondDateYear}", out var secondDate))
            {
                Console.WriteLine("Wrong date format");
                Console.ReadLine();
                return;
            }
            var bills = _billRepository.GetBetweenDates(firstDate, secondDate);
            foreach (var bill in bills)
            {
                PrintHelpers.PrintBill(bill, _billRepository.GetPrice(bill.Id));
            }
            Console.ReadLine();
        }
    }
}
