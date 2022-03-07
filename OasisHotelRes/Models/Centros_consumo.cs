using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisHotelRes.Models
{
    public class Centros_consumo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string concepto_es { get; set; }
        public string concepto_en { get; set; }
        public string logo { get; set; }
        public string img_portada { get; set; }
        public int categoria_id { get; set; }
    }
}
