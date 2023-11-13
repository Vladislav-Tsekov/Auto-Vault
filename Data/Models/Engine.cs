using System;
using System.Collections.Generic;

namespace VehicleData.Data.Models;

public partial class Engine
{
    public int Id { get; set; }

    public double? Displacement { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
