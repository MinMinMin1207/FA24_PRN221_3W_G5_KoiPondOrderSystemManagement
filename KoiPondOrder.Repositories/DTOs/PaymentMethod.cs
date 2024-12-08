using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories.DTOs
{
    public class PaymentMethod
    {
        public static List<Method> GetMethodList()
        {
            return new List<Method>()
            {
                new Method {Name = "BankTransfer"},
                new Method {Name = "Cash"},
                new Method {Name = "Card"}
            };
        }
    }

    public class Method
    {
        public string Name { get; set; } = null!;
    }
}
