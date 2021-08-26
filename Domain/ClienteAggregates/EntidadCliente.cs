using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ClienteAggregates
{
    public class EntidadCliente
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string fecha_nacimiento { get; set; }
        public string edad { get; set; }
    }
}
