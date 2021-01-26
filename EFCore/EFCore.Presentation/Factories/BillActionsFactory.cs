using EFCore.Domain.Factories;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions;
using EFCore.Presentation.Actions.BillActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Factories
{
    public static class BillActionsFactory
    {
        public static BillParentAction GetBillParentAction()
        {
            var actions = new List<IAction>
            {
                new AddItemBill(RepositoryFactory.GetRepository<BillRepository>(),
                    RepositoryFactory.GetRepository<SaleRepository>(),
                    RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<CustomerRepository>()),
                new AddServiceBill(RepositoryFactory.GetRepository<BillRepository>(),
                    RepositoryFactory.GetRepository<SaleRepository>(),
                    RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<CustomerRepository>()),
                new AddSubscriptionBill(RepositoryFactory.GetRepository<BillRepository>(),
                    RepositoryFactory.GetRepository<SaleRepository>(),
                    RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<CustomerRepository>()),
                new BillsBetweenDates(RepositoryFactory.GetRepository<BillRepository>()),
                new BillsFromCategories(RepositoryFactory.GetRepository<BillRepository>(),
                    RepositoryFactory.GetRepository<CategoryRepository>()),
                new BillsFromTypes(RepositoryFactory.GetRepository<BillRepository>()),
                new CancelBill(RepositoryFactory.GetRepository<BillRepository>()),
                new ExitMenuAction(),
            };

            return new BillParentAction(actions);
        }
    }
}
