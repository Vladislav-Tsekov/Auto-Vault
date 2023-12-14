using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models;

public partial class VehicleEngine
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Engine { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
