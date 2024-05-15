﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Admin
    {
        [Key, ForeignKey("user")]
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual user user { get; set; }
    }
}
