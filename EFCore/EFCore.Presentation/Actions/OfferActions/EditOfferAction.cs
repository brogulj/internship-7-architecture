using EFCore.Data.Entities.Models;
using EFCore.Data.Enums;
using EFCore.Domain.Enums;
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
    public class EditOfferAction :IAction
    {
        private readonly OfferRepository _offerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit offer";
        public EditOfferAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Call()
        {

            var offer = new Offer();
            foreach (var offerDbs in _offerRepository.GetAll())
            {
                PrintHelpers.PrintOffer(offerDbs);
            }
            Console.WriteLine("Enter the ID of the offer you'd like to edit");

            if (!ReadHelpers.TryReadNumber(out var offerId))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            var offerDb = _offerRepository.FindOfferById(offerId);
            if(offerDb == null)
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Console.Clear();
                return;
            }


            Console.WriteLine($"Enter the name of the offer: ({offerDb.Name})");
            if (!ReadHelpers.TryReadLineIfNotEmpty(out var name))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            offer.Name = name;

            Console.WriteLine($"Enter the price of the offer: ({offerDb.Price})");
            if (!ReadHelpers.TryReadNumber(out var price))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            offer.Price = price;

            Console.WriteLine($"Enter the ammount in the inventory: ({offerDb.AmmountLeft})");
            if (!ReadHelpers.TryReadNumber(out var ammountLeft))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            offer.AmmountLeft = ammountLeft;
            offer.Availability = true;
            offer.AmmountSold = 0;

            Console.WriteLine("Enter the type of the offer");
            Console.WriteLine("(1) item  (2)service  (3)  Subscription");
            if (!ReadHelpers.TryReadNumber(out var saleType))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            switch (saleType)
            {
                case 1:
                    offer.SaleType = SaleType.Item;
                    break;
                case 2:
                    offer.SaleType = SaleType.Service;
                    break;
                case 3:
                    offer.SaleType = SaleType.Subscription;
                    break;
                default:
                    Console.WriteLine("wrong input");
                    Console.ReadLine();
                    Console.Clear();
                    return;
            }
            if (offer.SaleType == SaleType.Service)
            {
                Console.WriteLine($"Enter the ID of the employee: ({offerDb.EmployeeId})");
                if (!ReadHelpers.TryReadNumber(out var employeeId))
                {
                    Console.WriteLine("wrong input");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                offer.EmployeeId = employeeId;
            }
            if (_offerRepository.Add(offer) == ResponseResultType.Success)
            {
                PrintHelpers.PrintOffer(offer);
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Console.WriteLine("Edit unsuccessfull");
            Console.ReadLine();
            Console.Clear();
            return;
        }
    }
}
