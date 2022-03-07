using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes.Models
{
    public class Centros_consumo_horarios
    {
        public int id { get; set; }
        public int centro_consumo_id { get; set; }
        public int dia { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_final { get; set; }
   
    }
}
