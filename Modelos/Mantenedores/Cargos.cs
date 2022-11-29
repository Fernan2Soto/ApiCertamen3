using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using Datos;

namespace Modelos.Mantenedores
{
    public class Cargos : IDataEntity
    {
        public int cod_cargo { get; set; }
        public string nombre { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
        public Cargos()
        {
            Data= new data();
            parametros= new List<Parametros>();
        }
    }
}
