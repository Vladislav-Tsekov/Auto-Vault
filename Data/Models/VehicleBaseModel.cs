using System.ComponentModel.DataAnnotations;
using VehicleData.Utilities;

namespace VehicleData.Data.Models
{
    public class VehicleBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.BaseModelMaxLength)]
        public string BaseModel { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
