using EFCore.Data.Entities.Models;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.InventoryActions
{
    public  class MoreLessInventory : IAction
    {
        private readonly OfferRepository _offerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get inventory above or below certain number";
        public MoreLessInventory(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Call()
        {
            Console.WriteLine("Do you want mabove or below certain number");
            Console.WriteLine("1. (above)  2. (below)");
            if(!ReadHelpers.TryReadNumber(out var choice))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Type in that number: ");
            if (!ReadHelpers.TryReadNumber(out var number))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }
            var offers = new List<Offer>();
            switch (choice)
            {
                case 1:
                    offers = _offerRepository.MoreThanInventory(number).ToList<Offer>();
                    break;
                case 2:
                    offers = _offerRepository.LessThanInventory(number).ToList<Offer>();
                    break;
                default:
                    break;
            }
            foreach (var offer in offers)
            {
                PrintHelpers.PrintOffer(offer);
            }
            Console.ReadLine();
        }

    }
}
