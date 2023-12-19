using Microsoft.VisualBasic;
using System.Linq;
using VehicleData.Data;
using VehicleData.Data.Models;
using VehicleData.Utilities;

namespace VehicleData.Core
{
    public class TablePopulation
    {
        public void YearTablePopulation(VehicleDataContext context) 
        {
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

                Console.WriteLine(GlobalConstants.YearTablePopulated);
            }
            else
            {
                Console.WriteLine(GlobalConstants.YearTableAlreadyPopulated);
            }
        }

        public void RestOfDataPopulation(VehicleDataContext context) 
        {
            using var reader = new StreamReader(GlobalConstants.FilePath);
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

                VehicleEngine engineExists = engines.FirstOrDefault(m => m.Engine == double.Parse(carData[2]));
                if (engineExists is null)
                {
                    var currentEngine = new VehicleEngine() { Engine = double.Parse(carData[2]) };
                    engines.Add(currentEngine);
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

                VehicleClass classExists = classes.FirstOrDefault(c => c.Class == carData[5]);
                if (classExists is null)
                {
                    var currentClass = new VehicleClass() { Class = carData[5] };
                    classes.Add(currentClass);
                }

                VehicleBaseModel baseModelExists = baseModels.FirstOrDefault(bm => bm.BaseModel == carData[7]);
                if (baseModelExists is null)
                {
                    var currentBaseModel = new VehicleBaseModel() { BaseModel = carData[7] };
                    baseModels.Add(currentBaseModel);
                }
            }

            reader.Dispose();

            string output = "";

            StreamWriter baseModelsWriter = new StreamWriter("../../../bmData.csv");
            baseModelsWriter.WriteLine($"INSERT INTO VehicleBaseModels (BaseModel){Environment.NewLine}VALUES");
            foreach (var bm in baseModels)
            {
                baseModelsWriter.WriteLine($"('{bm.BaseModel}'), ");
            }
            baseModelsWriter.Dispose();

            StreamWriter transmWriter = new StreamWriter("../../../transmData.csv");
            transmWriter.WriteLine($"INSERT INTO TransmissionTypes (Transmission){Environment.NewLine}VALUES");
            foreach (var t in transmissions)
            {
                transmWriter.WriteLine($"('{t.Transmission}'), ");
            }
            transmWriter.Dispose();

            StreamWriter driveWriter = new StreamWriter("../../../driveData.csv");
            driveWriter.WriteLine($"INSERT INTO DrivetrainTypes (Drivetrain){Environment.NewLine}VALUES");
            foreach (var d in drivetrains)
            {
                driveWriter.WriteLine($"('{d.Drivetrain}'), ");
            }
            driveWriter.Dispose();

            StreamWriter classWriter = new StreamWriter("../../../classData.csv");
            classWriter.WriteLine($"INSERT INTO VehicleClasses (Class){Environment.NewLine}VALUES");
            foreach (var c in classes)
            {
                classWriter.WriteLine($"('{c.Class}'), ");
            }
            classWriter.Dispose();

            StreamWriter makesWriter = new StreamWriter("../../../makeData.csv");
            makesWriter.WriteLine($"INSERT INTO VehicleMakes (Make){Environment.NewLine}VALUES");
            foreach (var mk in makes)
            {
                makesWriter.WriteLine($"('{mk.Make}'), ");
            }
            makesWriter.Dispose();

            StreamWriter modelsWriter = new StreamWriter("../../../modelData.csv");
            modelsWriter.WriteLine($"INSERT INTO VehicleModels (Model){Environment.NewLine}VALUES");
            foreach (var md in models)
            {
                modelsWriter.WriteLine($"('{md.Model}'), ");
            }
            modelsWriter.Dispose();

            context.Makes.AddRange(makes.OrderBy(mk => mk.Make));
            context.Models.AddRange(models.OrderBy(md => md.Model));
            context.Engines.AddRange(engines.OrderBy(eng => eng.Engine));
            context.DrivetrainTypes.AddRange(drivetrains.OrderBy(dt => dt.Drivetrain));
            context.TransmissionTypes.AddRange(transmissions.OrderBy(tr => tr.Transmission));
            context.VehicleClasses.AddRange(classes.OrderBy(cl => cl.Class));
            context.BaseModels.AddRange(baseModels.OrderBy(bm => bm.BaseModel));

            context.SaveChanges();

            Console.WriteLine(GlobalConstants.AllTablesPopulated);
        }
    }
}
