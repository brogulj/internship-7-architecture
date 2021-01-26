using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.OfferActions
{
    public class DeleteOfferAction : IAction
    {

        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete Offer";
        public DeleteOfferAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Call()
        {
            foreach (var offer in _offerRepository.GetAll())
            {
                PrintHelpers.PrintOffer(offer);
            }
            Console.WriteLine("Enter the ID of the offer you'd like to delete: ");
            if (!ReadHelpers.TryReadNumber(out var offerId))
            {
                Console.WriteLine("wrong input");
                return;
            }
            if (_offerRepository.Delete(offerId)== Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("successfully deleted the offer");
            }else
            {
                Console.WriteLine("Offer not deleted");
            }
        }
    }
}
