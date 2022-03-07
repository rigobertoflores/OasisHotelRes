using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes.Models
{
    public class Locaciones
    {
        public int id { get; set; }
        public string locacion { get; set; }
        public int hotel_id { get; set; }

    }
}
