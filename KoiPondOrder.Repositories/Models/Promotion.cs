using System;
using System.Collections.Generic;

namespace KoiPondOrderSystemManagement.Repositories.Models;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string PromotionName { get; set; } = null!;

    public decimal? DiscountPercentage { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? PointsRequired { get; set; }

    public int? MaxUsage { get; set; }

    public decimal? MinOrderValue { get; set; }

    public bool PromotionStatus { get; set; }

    public int RemainUsage { get; set; }

    public virtual ICollection<Design> Designs { get; set; } = new List<Design>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
