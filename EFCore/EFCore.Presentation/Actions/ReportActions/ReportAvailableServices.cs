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
    public class ReportAvailableServices : IAction
    {
        private readonly OfferRepository _offerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get all available Services";
        public ReportAvailableServices(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Call()
        {
            var services = _offerRepository.GetAvailableServices();
            foreach (var service in services)
            {
                PrintHelpers.PrintOffer(service);
            }
            Console.ReadLine();
        }
    }
}
