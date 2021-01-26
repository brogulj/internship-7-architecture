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
    public class RenameCategoryAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Rename category";
        public RenameCategoryAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Call()
        {
            Console.WriteLine("Enter the id of the category youd like to rename");
            if(!ReadHelpers.TryReadNumber(out var Id))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Enter the new name of the category you'd like to rename");
            if (!ReadHelpers.TryReadLineIfNotEmpty(out var name))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            if (_categoryRepository.Rename(name, Id) == Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("Category renamed successfully!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Category was not renamed");
            Console.ReadLine();
            return;
        }
    }
}
