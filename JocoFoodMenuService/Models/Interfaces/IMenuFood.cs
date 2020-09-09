using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JocoFoodMenuService.Models.Interfaces
{
    public interface IMenuFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile UploadedImage { get; set; }
        public string ImageUrl { get; set; }
    }
}
