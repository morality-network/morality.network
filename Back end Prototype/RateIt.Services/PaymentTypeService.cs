using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IRepository<PaymentType> _paymentTypesRepository;

        public PaymentTypeService(IRepository<PaymentType> paymentTypesRepository)
        {
            _paymentTypesRepository = paymentTypesRepository;
        }

        public PaymentType GetPaymentType(TransferType type)
        {
            return _paymentTypesRepository.GetAll()
                .FirstOrDefault(x => x.TypeName == type.ToString());
        }
    }
}
