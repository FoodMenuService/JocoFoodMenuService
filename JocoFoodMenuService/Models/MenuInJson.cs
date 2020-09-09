using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class MenuInJson
    {
        public List<string> Rice { get; set; }
        public List<string> Meats { get; set; }
        public List<string> Grains { get; set; }
        public List<string> Complements { get; set; }
        public List<string> Beverages { get; set; }
    }
}
