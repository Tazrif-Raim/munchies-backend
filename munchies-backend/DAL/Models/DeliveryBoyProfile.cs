using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class DeliveryBoyProfile
    {
        [Key]
        public int Id { get; set; }  // Primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAvailable { get; set; }  // Indicates availability for deliveries
        public string VehicleNumber { get; set; }
    }
}
