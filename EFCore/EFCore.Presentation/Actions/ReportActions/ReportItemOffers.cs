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
    public class ReportItemOffers : IAction
    {
        private readonly OfferRepository _itemOfferRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get all item offers";
        public ReportItemOffers(OfferRepository itemOfferRepository)
        {
            _itemOfferRepository = itemOfferRepository;
        }
        public void Call()
        {
            var offers = _itemOfferRepository.GetByType(Data.Enums.SaleType.Item);
            foreach (var offer in offers)
            {
                PrintHelpers.PrintOffer(offer);
            }
        }
    }
}
