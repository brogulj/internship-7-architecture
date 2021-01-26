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
    public class BillsFromCategories : IAction
    {
        private readonly BillRepository _billRepository;
        private readonly CategoryRepository _categoryRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get bills from categories ";
        public BillsFromCategories(BillRepository billRepository, CategoryRepository categoryRepository)
        {
            _billRepository = billRepository;
            _categoryRepository = categoryRepository;
        }
        public void Call()
        {
            Console.WriteLine("Type in the name of tha category you want to get bills from: ");
            if (!ReadHelpers.TryReadLineIfNotEmpty(out var categoryName))
            {
                Console.WriteLine("Wrong input");
                Console.ReadLine();
                return;
            }
            var category = _categoryRepository.FindById(_categoryRepository.FindIdBYName(categoryName));
            if (category == null)
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            var bills = _billRepository.GetByCategory(category);
            foreach (var bill in bills)
            {
                PrintHelpers.PrintBill(bill, _billRepository.GetPrice(bill.Id));
            }
            Console.ReadLine();
        }
    }
}
