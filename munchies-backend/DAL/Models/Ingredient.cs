using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        [ForeignKey("Recipe")]
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
