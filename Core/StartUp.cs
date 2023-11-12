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
            Controller controller = new();
            controller.ReadData();
        }
    }
}