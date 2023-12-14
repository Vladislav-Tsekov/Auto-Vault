using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models;

public partial class VehicleClass
{
    public int Id { get; set; }

    [Required]
    [MaxLength(DataConstraints.VehicleClassMaxLength)]
    public string Class { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
