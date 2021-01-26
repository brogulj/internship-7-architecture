using EFCore.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.CustomerActions
{
    public class CustomerParentAction : BaseParentAction
    {
        public CustomerParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage customers";
        }

        public override void Call()
        {
            Console.WriteLine("Customer Management");
            base.Call();
        }
    }
}
