using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class RiceObj
    {
        public string Nombre { get; set; }
        public string Foto { get; set; }

    }

    public class MeatObj
    {
        public string Nombre { get; set; }
        public string Foto { get; set; }

    }

    public class GrainObj
    {
        public string Nombre { get; set; }
        public string Foto { get; set; }

    }

    public class ComplementObj
    {
        public string Nombre { get; set; }
        public string Foto { get; set; }

    }

    public class BeverageObj
    {
        public string Nombre { get; set; }
        public string Foto { get; set; }

    }

    public class MenuDeserializeObj
    {
        public List<RiceObj> Rice { get; set; }
        public List<MeatObj> Meat { get; set; }
        public List<GrainObj> Grain { get; set; }
        public List<ComplementObj> Complement { get; set; }
        public List<BeverageObj> Beverage { get; set; }

    }
}
