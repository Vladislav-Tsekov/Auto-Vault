using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Model { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
