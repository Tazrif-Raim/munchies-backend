using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BrandDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string style { get; set; }
        //public List<RecipeDTO> Recipes { get; set; }
    }
}
