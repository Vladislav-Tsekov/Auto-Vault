using System;
using System.Collections.Generic;

namespace VehicleData.Data.Models;

public partial class Year
{
    public int Id { get; set; }

    public int? ManufacturingYear { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
