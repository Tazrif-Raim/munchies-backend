using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StockTableDTO
    {
        public int Id { get; set; }

        public string Company_Name { get; set; }

        public int Current_Price { get; set; }

        public int High_Price { get; set; }

        public int Low_Price { get; set; }


    }
}
