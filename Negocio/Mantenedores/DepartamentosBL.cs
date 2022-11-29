using Modelos;
using Modelos.Mantenedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Mantenedores
{
    public class DepartamentosBL : ICrud<Departamentos>
    {
        ResponseExec resp = new ResponseExec();
        public ResponseExec Create(Departamentos o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Departamentos (nombre_departamento, direccion, ciudad) VALUES('" + o.nombre_departamento + "','" + o.direccion + "','" + o.ciudad + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public ResponseExec Delete(Departamentos o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Departamentos WHERE cod_departamento='" + o.cod_departamento + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Departamentos> Get(Departamentos o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Departamentos"));
        }

        public Departamentos GetById(Departamentos o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Departamentos WHERE cod_departamento='" + o.cod_departamento + "'")).FirstOrDefault();
        }

        public List<Departamentos> GetQuery(Departamentos o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Departamentos WHERE nombre_departamento='" + o.nombre_departamento + "'"));
        }

        public ResponseExec Update(Departamentos o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Departamentos SET nombre_departamento='" + o.nombre_departamento + "', direccion='" + o.direccion + "', ciudad='" + o.ciudad + "' WHERE cod_departamento='" + o.cod_departamento + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Departamentos> convertToList(DataTable dt)
        {
            List<Departamentos> listado = new List<Departamentos>();

            foreach (DataRow item in dt.Rows)
            {
                Departamentos o = new Departamentos();
                o.cod_departamento = int.Parse(item.ItemArray[0].ToString());
                o.nombre_departamento = item.ItemArray[1].ToString();
                o.direccion = item.ItemArray[2].ToString();
                o.ciudad = item.ItemArray[3].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}
