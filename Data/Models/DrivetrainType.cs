using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models;

public partial class DrivetrainType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DataConstraints.DrivetrainMaxLength)]
    public string Drive { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
