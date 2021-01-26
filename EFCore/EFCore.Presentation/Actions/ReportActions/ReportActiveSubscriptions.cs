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
    public class ReportActiveSubscriptions : IAction
    {
        private readonly SaleRepository _saleRepository;
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Get active subscriptions";
        public ReportActiveSubscriptions(SaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public void Call()
        {
            var subscriptions = _saleRepository.GetActiveSubscriptions();
            foreach (var subscription in subscriptions)
            {
                PrintHelpers.PrintSale(subscription);
            }
        }
    }
}
