using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Order { get; set; }
        [Required]
        [StringLength(50)]
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }

        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

    }
}
