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
    public class AddOfferAction : IAction
    {
        private readonly OfferRepository _offerRepository;
        private readonly EmployeeRepository _emplyeeRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add Offer";
        public AddOfferAction(OfferRepository offerRepository,
            EmployeeRepository employeeRepository)
        {
            _offerRepository = offerRepository;
            _emplyeeRepository = employeeRepository;
        }
        public void Call()
        {
            var offer = new Offer();

            Console.WriteLine("Enter the name of the offer");
            if(!ReadHelpers.TryReadLineIfNotEmpty(out var name))
            {
                Console.WriteLine("wrong input");
                return;
            }
            offer.Name = name;

            Console.WriteLine("Enter the price of the offer");
            if (!ReadHelpers.TryReadNumber(out var price))
            {
                Console.WriteLine("wrong input");
                return;
            }
            offer.Price = price;

            Console.WriteLine("Enter the ammount in the inventory");
            if(!ReadHelpers.TryReadNumber(out var ammountLeft))
            {
                Console.WriteLine("wrong input");
                return;
            }
            offer.AmmountLeft = ammountLeft;
            offer.Availability = true;
            offer.AmmountSold = 0;

            Console.WriteLine("Enter the type of the offer");
            Console.WriteLine("(1) item  (2)service  (3)  Subscription");
            if(!ReadHelpers.TryReadNumber(out var saleType))
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
            if(offer.SaleType == SaleType.Service)
            {
                Console.WriteLine("Enter the ID of the employee: ");
                if(!ReadHelpers.TryReadNumber(out var employeeId))
                {
                    Console.WriteLine("wrong input");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                if (_emplyeeRepository.FindById(employeeId) == null)
                {
                    Console.WriteLine("That employee does not exist");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                offer.EmployeeId = employeeId;
                offer.Employee = _emplyeeRepository.FindById(employeeId);
            }
            if(_offerRepository.Add(offer) == ResponseResultType.Success)
            {
                PrintHelpers.PrintOffer(offer);
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Addition unsuccessfull");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
