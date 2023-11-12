using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleData.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VehicleData.Core
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DataPopulation data = new();

            //data.YearTablePopulation();
            data.MakeModelAndBaseModelPopulation();

            Controller controller = new();
            controller.ReadData();
        }
    }
}