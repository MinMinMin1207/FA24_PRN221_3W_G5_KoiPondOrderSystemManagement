using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int CustomerId { get; set; }

    public int ServiceOrProjectId { get; set; }

    public string? Content { get; set; }

    public int? Rating { get; set; }

    public DateTime SubmissionDate { get; set; }

    public bool ApprovalStatus { get; set; }

    public virtual User Customer { get; set; } = null!;
}
