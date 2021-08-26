using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class EntidadResponse
    {
        public int AffectedRows { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
