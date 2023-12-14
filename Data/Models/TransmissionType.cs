using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models;

public partial class TransmissionType
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Transmission { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
}
