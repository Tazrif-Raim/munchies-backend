using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DeliveryManDTO : userDTO
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string status { get; set; }
    }
}
