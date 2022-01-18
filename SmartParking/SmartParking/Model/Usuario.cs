using System;
using System.Collections.Generic;
using System.Text;

namespace SmartParking.Model
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string clave { get; set; }
        public string nombresCompletos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string contactoNombres { get; set; }
        public string contactoTelefono { get; set; }
        public int centralEmergenciaId { get; set; }
        public string tipo { get; set; }
        public bool login { get; set; }
        public bool resultado { get; set; }
        public int id_central { get; set; }
        public int id_cliente { get; set; }
    }
}
