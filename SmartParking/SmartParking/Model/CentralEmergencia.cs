using System;
using System.Collections.Generic;
using System.Text;

namespace SmartParking.Model
{
    public class CentralEmergencia
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string WHATSAPP { get; set; }
        public string TELEFONO { get; set; }
        public string ESTADO { get; set; }

        public override string ToString()
        {
            return NOMBRE;
        }
    }
}
