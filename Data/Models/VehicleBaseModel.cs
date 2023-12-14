using System.ComponentModel.DataAnnotations;

namespace VehicleData.Data.Models
{
    public class VehicleBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string BaseModel { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
