using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class MenuDeserializeObj
    {
        public List<List<string>> Rice { get; set; }
        public List<List<string>> Meat { get; set; }
        public List<List<string>> Grain { get; set; }
        public List<List<string>> Complement { get; set; }
        public List<List<string>> Beverage { get; set; }

    }
}
