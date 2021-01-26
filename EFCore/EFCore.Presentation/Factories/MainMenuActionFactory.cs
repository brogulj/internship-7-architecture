using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions;
using EFCore.Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Factories
{
    public static class MainMenuActionFactory
    {
        public static IList<IAction> GetMainMenuActions()
        {
            var actions = new List<IAction>
            {
                OfferActionsFactory.GetOfferParentAction(),
                CategoryActionsFactory.GetCategoryParentAction(),
                CustomerActionsFactory.GetCustomerParentAction(),
                InventoryActionsFactory.GetInventoryParentAction(),
                ReportsActionFactory.GetReportsParentAction(),
                BillActionsFactory.GetBillParentAction(),
                new ExitMenuAction(),
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
