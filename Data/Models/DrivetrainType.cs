using System;
using System.Collections.Generic;

namespace VehicleData.Data.Models;

public partial class DrivetrainType
{
    public int Id { get; set; }

    public string? Drive { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
