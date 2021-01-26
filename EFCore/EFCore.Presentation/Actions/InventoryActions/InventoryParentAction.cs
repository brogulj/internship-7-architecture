using EFCore.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.InventoryActions
{
    public class InventoryParentAction : BaseParentAction
    {
        public InventoryParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Inventory Actions";
        }
        public override void Call()
        {
            Console.WriteLine("Inventory Management");
            base.Call();
        }
    }
}
