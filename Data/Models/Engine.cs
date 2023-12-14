using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models;

public partial class Engine
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Displacement { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
