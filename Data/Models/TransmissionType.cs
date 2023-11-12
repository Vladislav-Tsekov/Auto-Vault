using System;
using System.Collections.Generic;

namespace VehicleData.Data.Models;

public partial class TransmissionType
{
    public int Id { get; set; }

    public string? Transmission { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
