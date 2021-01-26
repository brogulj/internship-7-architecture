using EFCore.Domain.Factories;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions;
using EFCore.Presentation.Actions.CustomerActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Factories
{
    public static class CustomerActionsFactory
    {
        public static CustomerParentAction GetCustomerParentAction()
        {
            var actions = new List<IAction>
            {
                new CustomerAddAction(RepositoryFactory.GetRepository<CustomerRepository>()),
                new CustomerDeleteAction(RepositoryFactory.GetRepository<CustomerRepository>()),
                new CustomerEditAction(RepositoryFactory.GetRepository<CustomerRepository>()),
                new ExitMenuAction()
            };

            return new CustomerParentAction(actions);
        }
    }
}
