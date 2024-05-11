using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public string OrderText { get; set; }
        public DateTime Time { get; set; }      
        public String OrderedBy { get; set; }       
        public int ResturantId { get; set; }
        
    }
}
