using System;
using System.Collections.Generic;

namespace KoiPondOrderSystemManagement.Repositories.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalCost { get; set; }

    public int? PaymentId { get; set; }

    public int? PromotionId { get; set; }

    public string? DeliveryAddress { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? OrderStatus { get; set; }

    public decimal FinalCost { get; set; }

    public string? OrderDescription { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Payment? Payment { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
