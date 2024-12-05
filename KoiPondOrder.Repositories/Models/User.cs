using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiPondOrder.Repositories.Models;

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

    [Required]
    public string? Gender { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<CustomerHistory> CustomerHistories { get; set; } = new List<CustomerHistory>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Pond> PondConsultingStaffs { get; set; } = new List<Pond>();

    public virtual ICollection<Pond> PondCustomers { get; set; } = new List<Pond>();

    public virtual ICollection<Pond> PondDesignStaffs { get; set; } = new List<Pond>();

    public virtual ICollection<Service> ServiceCustomers { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceStaffs { get; set; } = new List<Service>();
}
