using EFCore.Data.Entities.Models;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.CategoryActions
{
    public class AddCategoryToOffer : IAction
    {
        private readonly CategoryRepository _categoryRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add category to offer";
        public AddCategoryToOffer(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Call()
        {
            Console.WriteLine("Type id of the offer youd like to add a category to: ");
            if (!ReadHelpers.TryReadNumber(out var offerId))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Type the name of the category you want to be added: ");
            if (!ReadHelpers.TryReadLineIfNotEmpty(out var categoryName))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            if (_categoryRepository.AddLink(_categoryRepository.FindIdBYName(categoryName), offerId) == Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("Link successfully added");
            }
        }
    }
}
