using System;
using System.Collections.Generic;

namespace Project_travel.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string? Token { get; set; }

    public string Phone { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
