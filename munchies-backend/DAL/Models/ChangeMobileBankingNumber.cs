using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ChangeMobileBankingNumber
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public string NewPhoneNumber { get; set; }
        public string OldPhoneNumber { get; set; }
    }
}
