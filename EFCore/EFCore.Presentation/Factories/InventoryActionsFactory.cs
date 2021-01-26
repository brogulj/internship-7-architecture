using EFCore.Domain.Factories;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions.InventoryActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Factories
{
    public class InventoryActionsFactory
    {
        public static InventoryParentAction GetInventoryParentAction()
        {
            var actions = new List<IAction>
            {
                new ChangeInventoryStatus(RepositoryFactory.GetRepository<OfferRepository>()),
                new MoreLessInventory(RepositoryFactory.GetRepository<OfferRepository>())
            };

            return new InventoryParentAction(actions);
        }
    }
}
