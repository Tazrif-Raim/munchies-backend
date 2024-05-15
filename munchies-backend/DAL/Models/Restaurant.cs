using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Restaurant
    {
        [Key, ForeignKey("user")]
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

        public Restaurant()
        {
            Recipes = new List<Recipe>();
        }

        public virtual user user { get; set; }
    }
}
