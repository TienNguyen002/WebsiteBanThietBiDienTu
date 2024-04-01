using Domain.DTO.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        Task<IList<PaymentMethodDTO>> GetAllPaymentMethods();
        Task<PaymentMethodDTO> GetPaymentMethodById(int id);
        Task<bool> AddPaymentMethod(PaymentMethodEditModel model);
        Task<bool> DeletePaymentMethod(int id);
    }
}
