using EFCore.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.BillActions
{
    public class BillParentAction : BaseParentAction
    {
        public BillParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage Bills";
        }
        public override void Call()
        {
            Console.WriteLine("Bill Management");
            base.Call();
        }
    }
}
