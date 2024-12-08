using System;
using System.Collections.Generic;

namespace KoiPondOrderSystemManagement.Repositories.Models;

public partial class Pond
{
    public int PondId { get; set; }

    public int CustomerId { get; set; }

    public int? ConsultingStaffId { get; set; }

    public int? DesignStaffId { get; set; }

    public string? ConstructionStaffId { get; set; }

    public string PondName { get; set; } = null!;

    public string? DesignStyle { get; set; }

    public int? DesignId { get; set; }

    public int? PaymentId { get; set; }

    public int? PromotionId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual User? ConsultingStaff { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Design? Design { get; set; }

    public virtual User? DesignStaff { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
