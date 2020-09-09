using JocoFoodMenuService.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models
{
    public class Rice : IMenuFood
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        public IFormFile UploadedImage { get; set; }
        [Display(Name ="Picture")]
        public string ImageUrl { get; set; }

    }
}
