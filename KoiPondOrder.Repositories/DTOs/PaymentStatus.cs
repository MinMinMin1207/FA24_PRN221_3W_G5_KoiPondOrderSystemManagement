using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories.DTOs
{
    public class PaymentStatus
    {
        public static List<Status> GetStatusList()
        {
            return new List<Status>()
            {
                new Status {Name = "Paid"},
                new Status {Name = "Cancelled"},
                new Status {Name = "Pending"}
            };
        }
    }

    public class Status
    {
        public string Name { get; set; } = null!;
    }
}
