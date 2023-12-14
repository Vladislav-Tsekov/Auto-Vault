using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models;

public partial class Year
{
    public int Id { get; set; }

    [Required]
    public int ManufacturingYear { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
