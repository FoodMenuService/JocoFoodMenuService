using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class MenuCreator
    {
        public int Id { get; set; }

        [Display(Name = "Daily menu")]

        public string MenuDaily { get; set; }

        [Display(Name ="Date of menu")]
        public DateTime MenuDate { get; set; }
        
    }
}
