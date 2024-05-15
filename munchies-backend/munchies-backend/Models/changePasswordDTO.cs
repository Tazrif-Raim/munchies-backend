using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace munchies_backend.Models
{
    public class changePasswordDTO
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}