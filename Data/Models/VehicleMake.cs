using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models
{
    public class VehicleMake
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Make { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
