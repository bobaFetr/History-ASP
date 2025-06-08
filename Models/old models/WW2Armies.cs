using System.Collections.Generic;
using Historical__Facts_3.Controllers;

namespace Historical__Facts_3.Models
{
    public class WW2Armies  : HomeController
    {
        public string Country { get; set; } = string.Empty;
        public int ArmySize { get; set; }

        // Static method to provide sample data
        //public static List<WW2Armies> GetArmyData()
        public WW2Armies() : base(null)
        {
            Country = string.Empty;
        }

        public WW2Armies(ILogger<HomeController> logger) : base(logger)
        {
        }

        public static List<WW2Armies> GetArmyData()
        {
            return new List<WW2Armies>
            {
                new WW2Armies { Country = "Soviet Union", ArmySize = 34000000 },
                new WW2Armies { Country = "Germany", ArmySize = 18000000 },
                new WW2Armies { Country = "United States", ArmySize = 16000000 },
                new WW2Armies { Country = "China", ArmySize = 14000000 },
                new WW2Armies { Country = "Japan", ArmySize = 6000000 },
                new WW2Armies { Country = "United Kingdom", ArmySize = 5500000 },
                new WW2Armies { Country = "France", ArmySize = 5000000 },
                new WW2Armies { Country = "Italy", ArmySize = 4000000 },
                new WW2Armies { Country = "Bulgaria", ArmySize = 450000 },
                new WW2Armies { Country = "Hungary", ArmySize = 300000 },
                new WW2Armies { Country = "Romania", ArmySize = 2000000 },
                new WW2Armies { Country = "Finland", ArmySize = 500000 },
                new WW2Armies { Country = "Poland", ArmySize = 1000000 },
                new WW2Armies { Country = "Canada", ArmySize = 1000000 },
                new WW2Armies { Country = "Australia", ArmySize = 1000000 },
                new WW2Armies { Country = "New Zealand", ArmySize = 500000 },
                new WW2Armies { Country = "South Africa", ArmySize = 500000 }
            };
        }
    }
}