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
                string? currentCar = reader.ReadLine();
                string[] carData = currentCar.Split(';');

                VehicleDataContext? context = new();
            }

            reader.Dispose();
        }
    }
}
