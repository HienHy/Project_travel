using System;
using System.Collections.Generic;

namespace Project_travel.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int TripId { get; set; }

    public int UserId { get; set; }

    public int Qty { get; set; }

    public int Price { get; set; }

    public int? Status { get; set; }

    public virtual Trip Trip { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
