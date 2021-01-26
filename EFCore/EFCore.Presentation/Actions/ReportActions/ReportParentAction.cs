using EFCore.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.ReportActions
{
    public class ReportParentAction : BaseParentAction
    {
        public ReportParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Reports";
        }
        public override void Call()
        {
            Console.WriteLine("Reports");
            base.Call();
        }
    }
}
