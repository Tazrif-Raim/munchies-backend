using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BrandRecipeDTO : BrandDTO
    {
        public List<RecipeDTO> Recipes { get; set; }
    }
}
