using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StockTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Company_Name { get; set; }
        [Required]

        public int Current_Price { get; set; }
        [Required]
        public int High_Price { get; set; }
        [Required]
        public int Low_Price { get; set; }
    }
}
