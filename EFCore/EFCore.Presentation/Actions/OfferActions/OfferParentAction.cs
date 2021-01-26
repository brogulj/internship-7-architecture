using EFCore.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.OfferActions
{
    public class OfferParentAction : BaseParentAction
    {
        public OfferParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage Offers";
        }
        public override void Call()
        {
            Console.WriteLine("Offer Management");
            base.Call();
        }
    }
}
