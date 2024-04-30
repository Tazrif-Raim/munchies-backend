using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string style { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public Brand()
        {
            Recipes = new List<Recipe>();
        }
    }
}
