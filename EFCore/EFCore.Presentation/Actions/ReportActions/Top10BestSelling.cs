using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using System;
using EFCore.Presentation.Helpers;

namespace EFCore.Presentation.Actions.ReportActions
{
    public class Top10BestSelling : IAction
    {
        private readonly OfferRepository _offerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get top 10 best selling offers";
        public Top10BestSelling(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Call()
        {
            var offers = _offerRepository.Top10Sellers();
            foreach (var offer in offers)
            {
                PrintHelpers.PrintOffer(offer);
            }
            Console.ReadLine();
            Console.Clear();
        }
        
    }
}
