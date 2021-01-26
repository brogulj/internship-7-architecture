using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.ReportActions
{
    public class ReportSubscriptionOffers : IAction
    {
        private readonly OfferRepository _subscriptionOfferRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get all subscription offers";
        public ReportSubscriptionOffers(OfferRepository subscriptionOfferRepository)
        {
            _subscriptionOfferRepository = subscriptionOfferRepository;
        }
        public void Call()
        {

            var offers = _subscriptionOfferRepository.GetByType(Data.Enums.SaleType.Subscription);
            foreach (var offer in offers)
            {
                PrintHelpers.PrintOffer(offer);
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
