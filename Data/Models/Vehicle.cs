using System;
using System.Collections.Generic;

namespace VehicleData.Data.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? DrivetrainType { get; set; }

    public int? TransmissionType { get; set; }

    public int? VehicleSizeClass { get; set; }

    public int? Year { get; set; }

    public string? BaseModel { get; set; }




    public virtual DrivetrainType? DrivetrainTypeNavigation { get; set; }

    public virtual ICollection<Engine> Engines { get; set; } = new List<Engine>();

    public virtual TransmissionType? TransmissionTypeNavigation { get; set; }

    public virtual VehicleClass? VehicleSizeClassNavigation { get; set; }

    public virtual Year? YearNavigation { get; set; }
}
