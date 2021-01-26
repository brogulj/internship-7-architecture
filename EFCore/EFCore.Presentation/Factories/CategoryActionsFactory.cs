using EFCore.Domain.Factories;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions.CategoryActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Factories
{
    public static class CategoryActionsFactory
    {
        public static CategoryParentAction GetCategoryParentAction()
        {
            var actions = new List<IAction>
            {
                new AddCategoryAction(RepositoryFactory.GetRepository<CategoryRepository>()),
                new AddCategoryToOffer(RepositoryFactory.GetRepository<CategoryRepository>()),
                new RenameCategoryAction(RepositoryFactory.GetRepository<CategoryRepository>())
            };

            return new CategoryParentAction(actions);
        }
    }
}
