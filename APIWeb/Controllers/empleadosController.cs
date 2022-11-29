using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace APIWeb.Controllers
{
    public class empleadosController : ControllerBase
    {
        Empleados emp = new Empleados();
        EmpleadosBL empBL = new EmpleadosBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/emplados/nuevo")]
        public ActionResult Create(EmpleadosDTO o)
        {
            try
            {
                emp.rut = o.rut;
                emp.nombre = o.nombre_empleado;
                emp.apellidos = o.apellidos_empleados;
                emp.cargo.cod_cargo = o.cod_cargo;
                emp.jefe.rut = o.rut_jefe;
                return Ok(empBL.Create(emp));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/emplados/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(empBL.Get(emp)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/emplados/buscarrut")]
        public ActionResult Buscarrut(string rut)
        {
            try
            {
                emp.rut = rut;
                return Ok(convert(empBL.GetById(emp)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }



        [HttpGet]
        [Route("api/v1/emplados/buscarnombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                emp.nombre = nombre;
                return Ok(convertList(empBL.GetQuery(emp)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/emplados/eliminar")]
        public ActionResult Eliminar(EmpleadosDTO o)
        {
            try
            {
                emp.rut = o.rut;
                return Ok(empBL.Delete(emp));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/emplados/actualizar")]
        public ActionResult Actualizar(EmpleadosDTO o)
        {
            try
            {
                emp.rut = o.rut;
                emp.nombre = o.nombre_empleado;
                emp.apellidos = o.apellidos_empleados;
                emp.cargo.cod_cargo = o.cod_cargo;
                emp.jefe.rut = o.rut_jefe;
                return Ok(empBL.Update(emp));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<EmpleadosDTO> convertList(List<Empleados> lista)
        {
            List<EmpleadosDTO> list = new List<EmpleadosDTO>();
            foreach (var item in lista)
            {
                EmpleadosDTO el = new EmpleadosDTO(item.rut, item.nombre, item.apellidos, item.cargo.cod_cargo,item.jefe.rut);
                list.Add(el);

            }
            return list;

        }
        private EmpleadosDTO convert(Empleados item)
        {
            EmpleadosDTO obj = new EmpleadosDTO(item.rut, item.nombre, item.apellidos, item.cargo.cod_cargo, item.jefe.rut);
            return obj;

        }
    }
}
