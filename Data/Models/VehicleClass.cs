namespace VehicleData.Data.Models;

public partial class VehicleClass
{
    public int Id { get; set; }

    public string? Class { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
