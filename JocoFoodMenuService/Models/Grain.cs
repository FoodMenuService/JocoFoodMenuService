using JocoFoodMenuService.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class Grain : IMenuFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile UploadedImage { get; set; }
        public string ImageUrl { get; set; }
    }
}
