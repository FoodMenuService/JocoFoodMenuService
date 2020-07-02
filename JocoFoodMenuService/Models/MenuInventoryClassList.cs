using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class MenuInventoryClassList
    {
        public List<Rice> Rice { get; set; }
        public List<Meat> Meats { get; set; }
        public List<Grain> Grains { get; set; }
        public List<Complement> Complements { get; set; }
        public List<Beverage> Beverages { get; set; }
    }
}
