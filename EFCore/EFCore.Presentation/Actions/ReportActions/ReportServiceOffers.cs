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
    public class ReportServiceOffers : IAction
    {
        private readonly OfferRepository _serviceOfferRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get all service offers";
        public ReportServiceOffers(OfferRepository serviceOfferRepository)
        {
            _serviceOfferRepository = serviceOfferRepository;
        }
        public void Call()
        {
            var offers = _serviceOfferRepository.GetByType(Data.Enums.SaleType.Service);
            foreach (var offer in offers)
            {
                PrintHelpers.PrintOffer(offer);
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
