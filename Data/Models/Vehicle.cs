using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleData.Data.Models
{
    public partial class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(MakeNavigation))]
        public int VehicleMake { get; set; }

        [Required]
        [ForeignKey(nameof(ModelNavigation))]
        public int Model { get; set; }

        [Required]
        [ForeignKey(nameof(BaseModelNavigation))]
        public int BaseModel { get; set; }

        [Required]
        [ForeignKey(nameof(DisplacementNavigation))]
        public int Engine { get; set; }

        [Required]
        [ForeignKey(nameof(DrivetrainTypeNavigation))]
        public int DrivetrainType { get; set; }

        [Required]
        [ForeignKey(nameof(TransmissionTypeNavigation))]
        public int TransmissionType { get; set; }

        [Required]
        [ForeignKey(nameof(VehicleSizeClassNavigation))]
        public int VehicleSizeClass { get; set; }

        [Required]
        [ForeignKey(nameof(YearNavigation))]
        public int Year { get; set; }

        public virtual VehicleMake MakeNavigation { get; set; }
        public virtual VehicleModel ModelNavigation { get; set; }
        public virtual VehicleBaseModel BaseModelNavigation { get; set; }
        public virtual DrivetrainType DrivetrainTypeNavigation { get; set; }
        public virtual VehicleEngine DisplacementNavigation { get; set; }
        public virtual TransmissionType TransmissionTypeNavigation { get; set; }
        public virtual VehicleClass VehicleSizeClassNavigation { get; set; }
        public virtual Year YearNavigation { get; set; }
    }
}