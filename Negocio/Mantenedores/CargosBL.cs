using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class CargosBL : ICrud<Cargos>
    {
        ResponseExec resp = new ResponseExec();
        public ResponseExec Create(Cargos o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Cargos(nombre) VALUES('" + o.nombre + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;

        }

        public ResponseExec Delete(Cargos o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Cargos WHERE id_cargo='" + o.cod_cargo + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Cargos> Get(Cargos o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Cargos"));
        }

        public Cargos GetById(Cargos o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Cargos WHERE id_cargo='" + o.cod_cargo + "'")).FirstOrDefault();
        }

        public List<Cargos> GetQuery(Cargos o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Cargos WHERE nombre='" + o.nombre + "'"));
        }

        public ResponseExec Update(Cargos o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Cargos SET nombre='" + o.nombre + "' WHERE id_cargo='" + o.cod_cargo + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Cargos> convertToList(DataTable dt)
        {
            List<Cargos> listado = new List<Cargos>();

            foreach (DataRow item in dt.Rows)
            {
                Cargos o = new Cargos();
                o.cod_cargo =int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}
