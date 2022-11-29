using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ResponseExec
    {
        public bool error { get; set; }
        public string mensaje { get; set; }

        public ResponseExec()
        {
            error = false;
        }
    }
}
