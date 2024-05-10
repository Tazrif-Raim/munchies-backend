using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
        [StringLength(int.MaxValue)]
        public string DescriptionRestaurant { get; set; }
        public string DescriptionCustomer { get; set; }
        public string Category { get; set; }
        public int price { get; set; }
        public string videoPath { get; set; }

        public Guid? Brand_Id { get; set; }
    }
}
