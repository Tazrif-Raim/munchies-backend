using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Logistic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Restaurant { get; set; }
        [Required]
        [StringLength(60)]
        public string Description { get; set; }


    }
}
