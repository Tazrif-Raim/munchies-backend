﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminDTO : userDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
