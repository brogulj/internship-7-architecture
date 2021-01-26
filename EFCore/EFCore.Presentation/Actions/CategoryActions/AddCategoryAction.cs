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
    public class AddCategoryAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add category";
        public AddCategoryAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Call()
        {
            Console.WriteLine("Enter the name of the category you'd like to add");
            if(!ReadHelpers.TryReadLineIfNotEmpty(out var name))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            var category = new Category();
            category.Name = name;
            if(_categoryRepository.Add(category) == Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("Category added successfully!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Category was not added");
            Console.ReadLine();
            return;
        }
    }
}
