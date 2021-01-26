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
    public class ChangeInventoryStatus : IAction
    {
        private readonly OfferRepository _offerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Change Inventory Status";
        public ChangeInventoryStatus(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Call()
        {
            
            foreach (var offer in _offerRepository.GetAll())
            {
                PrintHelpers.PrintOffer(offer);
            }


            Console.WriteLine("Enter the id of the offer you want to change");
            if (!ReadHelpers.TryReadNumber(out var offerId))
            {
                Console.WriteLine("Error with ID input");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Console.Clear();

            var newOffer = _offerRepository.FindOfferById(offerId);
            PrintHelpers.PrintOffer(newOffer);

            Console.WriteLine("Enter the new value you want: "); 
            if (!ReadHelpers.TryReadNumber(out var newAmmount))
            {
                Console.WriteLine("Error with value input");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            if (newAmmount < 0)
                return;
            newOffer.AmmountLeft = newAmmount;

            if (_offerRepository.Edit(newOffer, offerId) == Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("Inventory successfully updated!");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
