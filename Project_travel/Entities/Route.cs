using System;
using System.Collections.Generic;

namespace Project_travel.Entities;

public partial class Route
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Starting { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
