using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.ReportActions
{
    public class YearlyReport : IAction
    {
        private readonly SaleRepository _billRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; }
        public YearlyReport(SaleRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public void Call()
        {
            Console.WriteLine("enter the year you want the report for:");
            if(!ReadHelpers.TryReadNumber(out var year))
            {
                Console.WriteLine("Wrong Input");
                return;
            }
            var revenue = 0;
            revenue = _billRepository.ProfitByYear(year);
            Console.WriteLine($"Total revenue in year {year}: {revenue}");
            Console.ReadLine();
        }
    }
}
