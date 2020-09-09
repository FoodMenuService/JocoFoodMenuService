using JocoFoodMenuService.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class UtilityClass
    {
        public static string SerializedMenu(IMenuFood menuFood)
        {
            return JsonConvert.SerializeObject(menuFood);
        }
    }
}
