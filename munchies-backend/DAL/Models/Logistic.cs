using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Logistic
    {
        [Key, ForeignKey("user")]
        public int id { get; set; }
        [Required]
        [StringLength(60)]
        public string Restaurant { get; set; }
        [Required]
        [StringLength(60)]
        public string Description { get; set; }

        public virtual user user { get; set; }
    }
}
