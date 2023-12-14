using VehicleData.Data;
using VehicleData.Data.Models;

namespace VehicleData.Core
{
    public class Controller
    {
        public void ReadData()
        {
            string filePath = @"all-vehicles-model.csv";

            VehicleDataContext context = new();
            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // Used to skip the first column - column's titles.

            while (!reader.EndOfStream)
            {
                string currentCar = reader.ReadLine();
                string[] carData = currentCar.Split(';');
                double.TryParse(carData[2], out double cc);
                int.TryParse(carData[6], out int outYear);

                var make = context.Makes.Single(m => m.Make == carData[0]);
                var model = context.Models.Single(m => m.Model == carData[1]);
                var displacement = context.Engines.Single(e => e.Displacement == cc);
                var drivetrain = context.DrivetrainTypes.Single(d => d.Drive == carData[3]);
                var transmissionType = context.TransmissionTypes.Single(t => t.Transmission == carData[4]);
                var vehicleSizeClass = context.VehicleClasses.Single(v => v.Class == carData[5]);
                var year = context.Years.Single(y => y.ManufacturingYear!.Value == outYear);
                var baseModel = context.BaseModels.Single(bm => bm.BaseModel == carData[7]);

                var vehicle = new Vehicle
                {
                    MakeNavigation = make,
                    ModelNavigation = model,
                    DisplacementNavigation = displacement,
                    DrivetrainTypeNavigation = drivetrain,
                    TransmissionTypeNavigation = transmissionType,
                    VehicleSizeClassNavigation = vehicleSizeClass,
                    YearNavigation = year,
                    BaseModelNavigation = baseModel
                };

                context.Vehicles.Add(vehicle);
            }

            context.SaveChanges();
            reader.Dispose();
        }
    }
}
