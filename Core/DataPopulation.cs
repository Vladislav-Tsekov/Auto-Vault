using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Data;
using VehicleData.Data.Models;

namespace VehicleData.Core
{
    public class DataPopulation
    {
        public void YearTablePopulation() 
        {
            var context = new VehicleDataContext();

            if (!context.Years.Any())
            {
                for (int year = 1984; year <= 2030; year++)
                {
                    context.Years.Add(new Year { ManufacturingYear = year });
                }

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Year table is already populated. Verify the data!");
            }
        }

        public void RestOfDataPopulation() 
        {
            VehicleDataContext? context = new();

            string filePath = @"all-vehicles-model.csv";
            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // Used to skip the first column - column's titles.

            while (!reader.EndOfStream)
            {
                string? currentCar = reader.ReadLine();
                string[] carData = currentCar.Split(';');

                var makeExists = context.Makes.FirstOrDefault(m => m.Make == carData[0]);
                if (makeExists is null)
                {
                    var currentMake = new VehicleMake() { Make = carData[0] };
                    context.Makes.Add(currentMake);
                    context.SaveChanges();
                }

                var modelExists = context.Models.FirstOrDefault(m => m.Model == carData[1]);
                if (modelExists is null)
                {
                    var currentModel = new VehicleModel() { Model = carData[1] };
                    context.Models.Add(currentModel);
                    context.SaveChanges();
                }

                if (double.TryParse(carData[2], out double displacementValue))
                {
                    var engineExists = context.Engines.FirstOrDefault(m => m.Displacement == displacementValue);
                    if (engineExists is null)
                    {
                        var currentEngine = new Engine() { Displacement = displacementValue };
                        context.Engines.Add(currentEngine);
                        context.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid double format: {carData[2]}");
                }

                var driveExists = context.DrivetrainTypes.FirstOrDefault(d => d.Drive == carData[3]);
                if (driveExists is null)
                {
                    var currentDrive = new DrivetrainType() { Drive = carData[3] };
                    context.DrivetrainTypes.Add(currentDrive);
                    context.SaveChanges();
                }

                var transmissionExists = context.TransmissionTypes.FirstOrDefault(t => t.Transmission == carData[4]);
                if (transmissionExists is null)
                {
                    var currentTransmission = new TransmissionType() { Transmission = carData[4] };
                    context.TransmissionTypes.Add(currentTransmission);
                    context.SaveChanges();
                }

                var classExists = context.VehicleClasses.FirstOrDefault(c => c.Class == carData[5]);
                if (classExists is null)
                {
                    var currentClass = new VehicleClass() { Class = carData[5] };
                    context.VehicleClasses.Add(currentClass);
                    context.SaveChanges();
                }

                var baseModelExists = context.BaseModels.FirstOrDefault(bm => bm.BaseModel == carData[7]);
                if (baseModelExists is null)
                {
                    var currentBaseModel = new VehicleBaseModel() { BaseModel = carData[7] };
                    context.BaseModels.Add(currentBaseModel);
                    context.SaveChanges();
                }
            }

            reader.Dispose();
        }
    }
}
