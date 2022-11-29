using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Modelos
{
    public interface IDataEntity
    {
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
    }
}
