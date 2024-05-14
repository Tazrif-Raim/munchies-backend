using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ChatProfileDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string secret { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string serverPassword { get; set; }
    }
}
