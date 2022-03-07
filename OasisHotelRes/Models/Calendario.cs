using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes.Models
{
    public class Calendario
    {
        public int id { get; set; }
        public DateTime Fecha{ get; set; }
        public DateTime hora_inicio  { get; set; }
        public DateTime hora_final { get; set; }
        public int duracion { get; set; }
        public int dia { get; set; }
    }
}
