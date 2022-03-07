using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes.Models
{
    public class Centros_consumo_detalles
    {
        public int id { get; set; }
        public int centro_consumo_id { get; set; }
        public int hotel_id { get; set; }
        public int destacado { get; set; }
     
    }
}
