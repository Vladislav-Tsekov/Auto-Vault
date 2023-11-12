using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleData.Data.Models
{
    public class VehicleMake
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Make { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
