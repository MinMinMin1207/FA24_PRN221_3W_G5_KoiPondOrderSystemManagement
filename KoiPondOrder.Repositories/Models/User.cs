﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiPondOrder.Repositories.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "Please input this field!")]
    [RegularExpression(@"^([A-Z][a-zA-Z]*\s)*[A-Z][a-zA-Z]*$", ErrorMessage = "Full name just contains a-z characters. The first letter of each word is capital!")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Please input this field!")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please input this field!")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Please input only number!")]
    [Length(10, 11, ErrorMessage = "Please input 10 or 11 phone number!")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Please input this field!")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Please input this field!")]
    public string Role { get; set; } = null!;

    [Required(ErrorMessage = "Please input this field!")]
    public string? PasswordHash { get; set; } = "Temp";

    [Required(ErrorMessage = "Please input this field!")]
    public DateOnly? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Please input this field!")]
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
