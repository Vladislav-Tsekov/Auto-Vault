using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models;

public partial class DrivetrainType
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Drive { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
