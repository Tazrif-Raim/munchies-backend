using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DeliveryMan
    {
        [Key, ForeignKey("user")]
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public ICollection<OrderLocation> OrderLocations { get; set; }
        public DeliveryMan()
        {
            OrderLocations = new List<OrderLocation>();
        }

        public virtual user user { get; set; }
    }
}
