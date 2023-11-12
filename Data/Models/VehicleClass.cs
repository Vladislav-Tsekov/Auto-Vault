using System;
using System.Collections.Generic;

namespace VehicleData.Data.Models;

public partial class VehicleClass
{
    public int Id { get; set; }

    public string? Class { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
