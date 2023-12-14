using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.ModelMaxLength)]
        public string Model { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
