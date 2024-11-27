using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public string? CancellationReason { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Discount { get; set; }

    public decimal FinalAmount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
