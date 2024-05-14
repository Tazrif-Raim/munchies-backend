using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ChangeMobileBankingNumberDTO
    {
        public string Password { get; set; }
        public string NewPhoneNumber { get; set; }
        public string OldPhoneNumber { get; set; }
    }
}
