using Microsoft.IdentityModel.Tokens;
using VehicleData.Data;
using VehicleData.Data.Models;

namespace VehicleData.Core
{
    public class DataPopulation
    {
        public void YearTablePopulation() 
        {
            var context = new VehicleDataContext();
            var yearsToAdd = new HashSet<Year>();

            if (!context.Years.Any())
            {
                for (int year = 1984; year <= 2030; year++)
                {
                    Year currentYear = new(){ ManufacturingYear = year};
                    yearsToAdd.Add(currentYear);
                }

                context.Years.AddRange(yearsToAdd);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Year table is already populated. Verify the data!");
            }
        }

        public void RestOfDataPopulation() 
        {
            VehicleDataContext context = new();

            string filePath = @"all-vehicles-model.csv";
            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // Used to skip the first row - column's titles.

            HashSet<VehicleMake> makes = new();
            HashSet<VehicleModel> models = new();
            HashSet<VehicleBaseModel> baseModels = new();
            HashSet<VehicleClass> classes = new();
            HashSet<VehicleEngine> engines = new();
            HashSet<DrivetrainType> drivetrains = new();
            HashSet<TransmissionType> transmissions = new();

            while (!reader.EndOfStream)
            {
                string currentCar = reader.ReadLine();
                string[] carData = currentCar.Split(';');

                VehicleMake makeExists = makes.FirstOrDefault(m => m.Make == carData[0]);
                if (makeExists is null)
                {
                    var currentMake = new VehicleMake() { Make = carData[0] };
                    makes.Add(currentMake);
                }

                VehicleModel modelExists = models.FirstOrDefault(m => m.Model == carData[1]);
                if (modelExists is null)
                {
                    var currentModel = new VehicleModel() { Model = carData[1] };
                    models.Add(currentModel);
                }

                VehicleBaseModel baseModelExists = baseModels.FirstOrDefault(bm => bm.BaseModel == carData[7]);
                if (baseModelExists is null)
                {
                    var currentBaseModel = new VehicleBaseModel() { BaseModel = carData[7] };
                    baseModels.Add(currentBaseModel);
                }

                VehicleClass classExists = classes.FirstOrDefault(c => c.Class == carData[5]);
                if (classExists is null)
                {
                    var currentClass = new VehicleClass() { Class = carData[5] };
                    classes.Add(currentClass);
                }

                if (double.TryParse(carData[2], out double displacementValue))
                {
                    VehicleEngine engineExists = engines.FirstOrDefault(m => m.Engine == displacementValue);
                    if (engineExists is null)
                    {
                        var currentEngine = new VehicleEngine() { Engine = displacementValue };
                        engines.Add(currentEngine);
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid or null displacement value: ->{carData[2]}<-.");
                }

                DrivetrainType driveExists = drivetrains.FirstOrDefault(d => d.Drivetrain == carData[3]);
                if (driveExists is null)
                {
                    var currentDrive = new DrivetrainType() { Drivetrain = carData[3] };
                    drivetrains.Add(currentDrive);
                }

                TransmissionType transmissionExists = transmissions.FirstOrDefault(t => t.Transmission == carData[4]);
                if (transmissionExists is null)
                {
                    var currentTransmission = new TransmissionType() { Transmission = carData[4] };
                    transmissions.Add(currentTransmission);
                }
            }

            reader.Dispose();

            var orderedEngines = engines.OrderBy(oe => oe.Engine);

            List<DrivetrainType> validDrivetrains = new(drivetrains);
            validDrivetrains.RemoveAll(dt => dt.Drivetrain.IsNullOrEmpty());

            List<TransmissionType> validTransmissions = new(transmissions);
            validTransmissions.RemoveAll(t => t.Transmission.IsNullOrEmpty());

            context.Makes.AddRange(makes);
            context.Models.AddRange(models);
            context.BaseModels.AddRange(baseModels);
            context.VehicleClasses.AddRange(classes);
            context.Engines.AddRange(orderedEngines);
            context.DrivetrainTypes.AddRange(validDrivetrains);
            context.TransmissionTypes.AddRange(validTransmissions);
            context.SaveChanges();
        }
    }
}
