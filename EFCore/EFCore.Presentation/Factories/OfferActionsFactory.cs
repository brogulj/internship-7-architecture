using EFCore.Domain.Factories;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions.OfferActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Factories
{
    public static class OfferActionsFactory
    {
        public static OfferParentAction GetOfferParentAction()
        {
            var actions = new List<IAction>
            {
                new AddOfferAction(RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<EmployeeRepository>()),
                new DeleteOfferAction(RepositoryFactory.GetRepository<OfferRepository>()),
                new EditOfferAction(RepositoryFactory.GetRepository<OfferRepository>())
            };

            return new OfferParentAction(actions);
        }
    }
}
