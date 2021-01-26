using EFCore.Presentation.Abstractions;
using System;
using System.Collections.Generic;

namespace EFCore.Presentation.Actions.CategoryActions
{
    public class CategoryParentAction : BaseParentAction
    {
        public CategoryParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage Categories";
        }
        public override void Call()
        {
            Console.WriteLine("Category Management");
            base.Call();
        }
    }
}
