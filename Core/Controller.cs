using Microsoft.EntityFrameworkCore;
using System.Text;
using VehicleData.Data;
using VehicleData.Data.Models;

namespace VehicleData.Core
{
    public class Controller
    {
        public void ReadData()
        {
            HashSet<Vehicle> cars = new();

            string filePath = @"all-vehicles-model.csv";
            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // Used to skip the first column - column's titles.

            while (!reader.EndOfStream)
            {
                VehicleDataContext? context = new();
                string? currentCar = reader.ReadLine();
                string[] carData = currentCar.Split(';');
                double.TryParse(carData[2], out double cc);
                int.TryParse(carData[6], out int year);

                var vehicle = new Vehicle
                {
                    MakeNavigation = context.Makes.Single(m => m.Make == carData[0]),
                    ModelNavigation = context.Models.Single(m => m.Model == carData[1]),
                    DisplacementNavigation = context.Engines.Single(e => e.Displacement == cc),
                    DrivetrainTypeNavigation = context.DrivetrainTypes.Single(d => d.Drive == carData[3]),
                    TransmissionTypeNavigation = context.TransmissionTypes.Single(t => t.Transmission == carData[4]),
                    VehicleSizeClassNavigation = context.VehicleClasses.Single(v => v.Class == carData[5]),
                    YearNavigation = context.Years.Single(y => y.ManufacturingYear!.Value == year),
                    BaseModelNavigation = context.BaseModels.Single(bm => bm.BaseModel == carData[7])
                };

                context.Vehicles.Add(vehicle);
                context.SaveChangesAsync();
            }

            reader.Dispose();
        }
    }
}
