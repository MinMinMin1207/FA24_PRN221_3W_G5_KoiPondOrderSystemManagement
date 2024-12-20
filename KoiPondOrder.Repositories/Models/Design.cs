﻿using System;
using System.Collections.Generic;

namespace KoiPondOrderSystemManagement.Repositories.Models;

public partial class Design
{
    public int DesignId { get; set; }

    public string DesignName { get; set; } = null!;

    public string? DesignStyle { get; set; }

    public decimal? EstimatedCost { get; set; }

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public int? PopularityScore { get; set; }

    public string? RecommendedUse { get; set; }

    public int? PromotionId { get; set; }

    public bool ApprovalStatus { get; set; }

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual Promotion? Promotion { get; set; }
}
