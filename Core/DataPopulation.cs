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

        public void MakeModelAndBaseModelPopulation() 
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
