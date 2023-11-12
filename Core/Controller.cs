namespace VehicleData.Core
{
    public class Controller
    {
        public void ReadData() 
        {
            string filePath = @"all-vehicles-model.csv";

            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // Used to skip the title's column.


            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                string[] data = line.Split(',');

            }

            reader.Dispose();
        }
    }
}
