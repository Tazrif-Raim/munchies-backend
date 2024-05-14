﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Order { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int? ProfileId { get; set; }
    }
}
