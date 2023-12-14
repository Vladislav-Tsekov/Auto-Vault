using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models
{
    public class VehicleMake
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.MakeMaxLength)]
        public string Make { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
