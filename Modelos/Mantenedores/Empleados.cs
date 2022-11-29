using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedores
{
    public class Empleados : IDataEntity
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public Cargos cargo { get; set; }
        public Jefes jefe { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
        public Empleados()
        {
            cargo = new Cargos();
            jefe = new Jefes();
            Data = new data();
            parametros = new List<Parametros>(); 
            
        }

    }
}
