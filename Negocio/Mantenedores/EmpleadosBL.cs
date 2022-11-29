using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Mantenedores;
using Datos;
using System.Data;

namespace Negocio.Mantenedores
{
    public class EmpleadosBL : ICrud<Empleados>
    {
        ResponseExec resp = new ResponseExec();
        public ResponseExec Create(Empleados o)
        {
            try
            {
                resp.error = !o.Data.execData("INSERT  INTO Empleados(rut, nombre, apellidos, id_cargo, id_jefe) VALUES('" + o.rut + "','" + o.nombre + "','" + o.apellidos + "','" + o.cargo.cod_cargo + "','" + o.jefe.rut + "')");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public ResponseExec Delete(Empleados o)
        {
            try
            {
                resp.error = !o.Data.execData("DELETE FROM Empleados WHERE rut='" + o.rut + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Empleados> Get(Empleados o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Empleados"));
        }

        public Empleados GetById(Empleados o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Empleados WHERE RUT='" + o.rut + "'")).FirstOrDefault();
        }

        public List<Empleados> GetQuery(Empleados o)
        {
            return convertToList(o.Data.queryData("SELECT * FROM Empleados WHERE NOMBRE='" + o.nombre + "'"));
        }

        public ResponseExec Update(Empleados o)
        {
            try
            {
                resp.error = !o.Data.execData("UPDATE Empleados SET nombre='" + o.nombre + "', apellidos='" + o.apellidos + "', id_cargo='" + o.cargo.cod_cargo + "', id_jefe='" + o.jefe.rut + "' WHERE RUT='" + o.rut + "'");
                resp.mensaje = "ok";
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = e.Message;

            }
            return resp;
        }

        public List<Empleados> convertToList(DataTable dt)
        {
            List<Empleados> listado = new List<Empleados>();

            foreach (DataRow item in dt.Rows)
            {
                Empleados o = new Empleados();
                o.rut = item.ItemArray[0].ToString();
                o.nombre = item.ItemArray[1].ToString();
                o.apellidos = item.ItemArray[2].ToString();
                o.cargo.cod_cargo =int.Parse(item.ItemArray[3].ToString());
                o.jefe.rut = item.ItemArray[4].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}
