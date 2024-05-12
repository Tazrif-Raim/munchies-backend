using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }
        [Required]
        [StringLength(50)]
        public string CurrentPassword { get; set; }
        [Required]
        [StringLength(50)]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }


        /*public int Phone { get; set; }...email
        public string Address {  get; set; }
        public string PaymentMethod { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }*/
    }
}
