using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class user
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        //user role maybe admin/employee/bus-providers/customer
        public string userRole { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DeliveryMan DeliveryMan { get; set; }
        public virtual Logistic Logistic { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
