using System.Collections.Generic;

namespace EFCore.Presentation.Abstractions
{
    public interface IParentAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }
}
