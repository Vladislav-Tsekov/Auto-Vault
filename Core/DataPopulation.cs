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
        public void YearsTablePopulation() 
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
                Console.WriteLine("Years table is already populated. Verify the data in it.");
            }
        }
    }
}
