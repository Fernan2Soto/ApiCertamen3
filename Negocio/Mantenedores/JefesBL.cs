using Modelos;
using Modelos.Mantenedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio.Mantenedores
{
    public class JefesBL : ICrud<Jefes>
    {
        ResponseExec resp = new ResponseExec();
        public ResponseExec Create(Jefes o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Jefes(rut, nombre, apellidos, id_departameto) VALUES('" + o.rut + "','" + o.nombre + "','" + o.apellidos + "','" + o.departamento.cod_departamento + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public ResponseExec Delete(Jefes o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Jefes WHERE rut='" + o.rut + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Jefes> Get(Jefes o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM jefes"));
        }

        public Jefes GetById(Jefes o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Jefes WHERE RUT='" + o.rut + "'")).FirstOrDefault();
        }

        public List<Jefes> GetQuery(Jefes o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Jefes WHERE NOMBRE='" + o.nombre + "'"));
        }

        public ResponseExec Update(Jefes o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Jefes SET nombre='" + o.nombre + "', apellidos='" + o.apellidos + "', id_departameto='" + o.departamento.cod_departamento + "' WHERE RUT='" + o.rut + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Jefes> convertToList(DataTable dt)
        {
            List<Jefes> listado = new List<Jefes>();

            foreach (DataRow item in dt.Rows)
            {
                Jefes o = new Jefes();
                o.rut = item.ItemArray[0].ToString();
                o.nombre = item.ItemArray[1].ToString();
                o.apellidos = item.ItemArray[2].ToString();
                o.departamento.cod_departamento = int.Parse(item.ItemArray[3].ToString());
                listado.Add(o);
            }

            return listado;
        }
    }
}
