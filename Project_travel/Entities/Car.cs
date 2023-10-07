using System;
using System.Collections.Generic;

namespace Project_travel.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public string Type { get; set; } = null!;

    public int Chair { get; set; }

    public string Company { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
