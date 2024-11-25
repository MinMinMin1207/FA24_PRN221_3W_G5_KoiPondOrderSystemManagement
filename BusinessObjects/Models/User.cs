using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public string Role { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<CustomerHistory> CustomerHistories { get; set; } = new List<CustomerHistory>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Project> ProjectConsultingStaffs { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectCustomers { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectDesignStaffs { get; set; } = new List<Project>();

    public virtual ICollection<Service> ServiceCustomers { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceStaffs { get; set; } = new List<Service>();
}
