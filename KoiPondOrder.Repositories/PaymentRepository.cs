using KoiPondOrder.Repositories;
using KoiPondOrder.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>
    {
        public PaymentRepository() { }

        public List<Payment> Search(string? paymentMethod = null, DateTime? fromDate = null, DateTime? toDate = null, string? status = null)
        {
            try
            {
                using var _context = new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext();
                var listPayments = _context.Payments.ToList().AsEnumerable();

                if (!string.IsNullOrEmpty(paymentMethod))
                {
                    listPayments = listPayments.Where(u => u.PaymentMethod.ToLower().Equals(paymentMethod.ToLower()));
                }

                if (fromDate.HasValue)
                {
                    listPayments = listPayments.Where(u => u.PaymentDate >= fromDate);
                }

                if (toDate.HasValue)
                {
                    listPayments = listPayments.Where(u => u.PaymentDate <= toDate);
                }

                if (!string.IsNullOrEmpty(status))
                {
                    listPayments = listPayments.Where(u => u.PaymentStatus.ToLower().Equals(status.ToLower()));
                }

                return listPayments.OrderByDescending(l => l.PaymentDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
