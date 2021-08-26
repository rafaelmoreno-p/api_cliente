using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ClienteAggregates
{
    public class RequestCliente
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string fecha_nacimiento { get; set; }
    }
}
