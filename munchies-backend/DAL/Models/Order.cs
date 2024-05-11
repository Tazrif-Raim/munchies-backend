using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string OrderText { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("User")]
        public String OrderedBy { get; set; }
        [ForeignKey("Resturant")]
        public int ResturantId { get; set; }
        public virtual Resturant Resturant { get; set; }
        public virtual User User { get; set; }
    }
}
