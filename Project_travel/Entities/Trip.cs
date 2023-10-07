using System;
using System.Collections.Generic;

namespace Project_travel.Entities;

public partial class Trip
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int RouteId { get; set; }

    public int CarId { get; set; }

    public DateTime DepatureDate { get; set; }

    public TimeSpan DepatureTime { get; set; }

    public int EmptySeat { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Route Route { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
