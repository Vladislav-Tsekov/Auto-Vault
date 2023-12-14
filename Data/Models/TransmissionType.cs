using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models;

public partial class TransmissionType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DataConstraints.TransmissionMaxLength)]
    public string Transmission { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
