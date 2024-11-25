using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class CustomerHistory
{
    public int HistoryId { get; set; }

    public int CustomerId { get; set; }

    public string OrderType { get; set; } = null!;

    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public decimal? TotalCost { get; set; }

    public int? Rating { get; set; }

    public string? Feedback { get; set; }

    public virtual User Customer { get; set; } = null!;
}
