using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderLocation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("Meal")]
        public int? MealId { get; set; }
        public virtual Meal Meal { get; set; }
        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
