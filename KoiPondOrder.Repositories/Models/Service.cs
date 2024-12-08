using System;
using System.Collections.Generic;

namespace KoiPondOrderSystemManagement.Repositories.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public int CustomerId { get; set; }

    public int? StaffId { get; set; }

    public string ServiceType { get; set; } = null!;

    public DateTime ServiceDate { get; set; }

    public string ServiceStatus { get; set; } = null!;

    public int? PaymentId { get; set; }

    public int? PromotionId { get; set; }

    public string? Result { get; set; }

    public string? Feedback { get; set; }

    public int? Rating { get; set; }

    public decimal? Cost { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Payment? Payment { get; set; }

    public virtual Promotion? Promotion { get; set; }

    public virtual User? Staff { get; set; }
}
