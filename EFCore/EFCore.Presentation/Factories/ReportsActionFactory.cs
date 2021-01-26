using EFCore.Domain.Factories;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Actions.ReportActions;
using System.Collections.Generic;

namespace EFCore.Presentation.Factories
{
    public static class ReportsActionFactory
    {
        public static ReportParentAction GetReportsParentAction()
            {
                var actions = new List<IAction>
            {
                new ReportActiveSubscriptions(RepositoryFactory.GetRepository<SaleRepository>()),
                new ReportAvailableServices(RepositoryFactory.GetRepository<OfferRepository>()),
                new ReportByCategory(RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<CategoryRepository>()),
                new ReportItemOffers(RepositoryFactory.GetRepository<OfferRepository>()),
                new ReportServiceOffers(RepositoryFactory.GetRepository<OfferRepository>()),
                new ReportSubscriptionOffers(RepositoryFactory.GetRepository<OfferRepository>()),
                new Top10BestSelling(RepositoryFactory.GetRepository<OfferRepository>()),
                new YearlyReport(RepositoryFactory.GetRepository<SaleRepository>())
            };

                return new ReportParentAction(actions);
        }
    }
}
