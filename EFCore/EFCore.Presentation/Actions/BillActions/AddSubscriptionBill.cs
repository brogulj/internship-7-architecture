﻿using EFCore.Data.Entities.Models;
using EFCore.Domain.Repositories;
using EFCore.Presentation.Abstractions;
using EFCore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Presentation.Actions.BillActions
{
    public class AddSubscriptionBill : IAction
    {
        private readonly BillRepository _billRepository;
        private readonly SaleRepository _saleRepository;
        private readonly OfferRepository _offerRepository;
        private readonly CustomerRepository _customerRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add subscription Bill";
        public AddSubscriptionBill(BillRepository billRepository, 
            SaleRepository saleRepository, 
            OfferRepository offerRepository,
            CustomerRepository customerRepository)
        {
            _billRepository = billRepository;
            _saleRepository = saleRepository;
            _offerRepository = offerRepository;
            _customerRepository = customerRepository;
        }
        public void Call()
        {
            var bill = _billRepository.AddNewBill(Data.Enums.SaleType.Subscription);

            Console.WriteLine("Type Id of the customer");
            if (!ReadHelpers.TryReadNumber(out var customerId))
            {
                Console.WriteLine("wrong input");
                Console.ReadLine();
                return;
            }

            var customer = _customerRepository.GetAll()
                .Where(c => c.Id == customerId)
                .ToList()
                .First();

            if (customer == null)
            {
                Console.WriteLine("wrong customer id number");
                Console.ReadLine();
                return;
            }

            foreach (var offer in _offerRepository.GetByType(Data.Enums.SaleType.Subscription))
            {
                PrintHelpers.PrintOffer(offer);
            }

            Console.WriteLine("Type IDs of offers you'd like to add to this bill");

            ReadHelpers.TryReadLineIfNotEmpty(out string IDs);

            var splitIDs = IDs.Split(' ').Select(Int32.Parse).ToList();
            var selectedSubscriptionOffers = new List<Offer>();

            foreach (var ID in splitIDs)
            {
                selectedSubscriptionOffers.Add(_offerRepository.GetAll().ElementAt(ID));
            }
            foreach (var offer in selectedSubscriptionOffers)
            {
                var sale = new Sale();
                var ammount = 0;

                foreach (var offer2 in selectedSubscriptionOffers)
                {
                    if (offer2 == offer)
                        ammount++;
                }

                sale.SaleDate = DateTime.Now;
                sale.Ammount = ammount;
                if (ammount > offer.AmmountLeft)
                    ammount = offer.AmmountLeft;
                sale.Offer = offer;
                sale.OfferId = offer.Id;
                sale.Offer.AmmountLeft -= ammount;
                sale.Offer.AmmountSold += ammount;
                sale.SaleType = Data.Enums.SaleType.Subscription;
                sale.StartTime = DateTime.Now;
                sale.EndTime = DateTime.Now.AddMonths(ammount);
                sale.Validity = true;
                sale.Bill = bill;
                sale.BillId = bill.Id;
                _saleRepository.Add(sale);
                bill.Customer = customer;
                bill.CustomerId = customer.Id;
                _billRepository.AddSaleToBill(sale, bill);
                selectedSubscriptionOffers.RemoveAll(s => s == offer);
            }

            PrintHelpers.PrintBill(bill, _billRepository.GetPrice(bill.Id));
        }
    }
}
