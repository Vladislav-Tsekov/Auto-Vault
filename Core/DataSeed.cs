using VehicleData.Data;
using VehicleData.Data.Models;
using VehicleData.Utilities;

namespace VehicleData.Core
{
    public class DataSeed
    {
        public void SeedData(VehicleDataContext context)
        {
            using var reader = new StreamReader(GlobalConstants.FilePath);
            reader.ReadLine(); // Used to skip the first column - column's titles.

            var validVehicles = new HashSet<Vehicle>();

            while (!reader.EndOfStream)
            {
                string currentCar = reader.ReadLine();
                string[] carData = currentCar.Split(';');

                bool ccParse = double.TryParse(carData[2], out double cc);
                bool yearParse = int.TryParse(carData[6], out int outYear);

                if (ccParse == false || yearParse == false)
                {
                    continue;
                }

                //TODO - Branch out and experiment list completion, etc.

                var VehicleMake = context.Makes.Single(m => m.Make == carData[0]);
                var model = context.Models.Single(m => m.Model == carData[1].TrimEnd());
                var displacement = context.Engines.Single(e => e.Engine == cc);
                var drivetrain = context.DrivetrainTypes.Single(d => d.Drivetrain == carData[3]);
                var transmissionType = context.TransmissionTypes.Single(t => t.Transmission == carData[4]);
                var vehicleSizeClass = context.VehicleClasses.Single(v => v.Class == carData[5]);
                var year = context.Years.Single(y => y.ManufacturingYear == outYear);
                var baseModel = context.BaseModels.Single(bm => bm.BaseModel == carData[7]);

                var vehicle = new Vehicle
                {
                    MakeNavigation = VehicleMake,
                    ModelNavigation = model,
                    DisplacementNavigation = displacement,
                    DrivetrainTypeNavigation = drivetrain,
                    TransmissionTypeNavigation = transmissionType,
                    VehicleSizeClassNavigation = vehicleSizeClass,
                    YearNavigation = year,
                    BaseModelNavigation = baseModel
                };

                validVehicles.Add(vehicle);
            }

            reader.Dispose();

            context.Vehicles.AddRange(validVehicles);
            context.SaveChanges();
        }
    }
}
