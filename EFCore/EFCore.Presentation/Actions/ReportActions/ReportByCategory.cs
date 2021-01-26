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
    public class ReportByCategory : IAction
    {
        private readonly OfferRepository _offerRepository;
        private readonly CategoryRepository _categoryRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Sales report by cateogry";
        public ReportByCategory(OfferRepository itemOfferRepository, CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _offerRepository = itemOfferRepository;
        }
        public void Call()
        {
            Console.WriteLine("Enter the name of the category youd like to see report on");
            if (!ReadHelpers.TryReadLineIfNotEmpty(out var categoryName))
            {
                Console.WriteLine("Wrong input");
                Console.ReadLine();
                return;
            }
            var category = _categoryRepository.FindById( _categoryRepository.FindIdBYName(categoryName));
            Console.WriteLine($"Number of sales in {category.Name}: {_offerRepository.SalesByCategory(category)}");
            Console.ReadLine();
        }
    }
}
