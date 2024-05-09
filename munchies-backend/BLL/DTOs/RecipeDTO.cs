using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
        public string DescriptionRestaurant { get; set; }
        public string DescriptionCustomer { get; set; }
        public string Category { get; set; }
        public int price { get; set; }
        public string videoPath { get; set; }

    }
}
