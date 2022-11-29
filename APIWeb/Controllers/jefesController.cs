using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace APIWeb.Controllers
{
    [ApiController]
    public class jefesController : ControllerBase
    {
        Jefes jefe = new Jefes();
        JefesBL jefeBL = new JefesBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/jefes/nuevo")]
        public ActionResult Create(JefesDTO o)
        {
            try
            {
                jefe.rut = o.rut;
                jefe.nombre = o.nombre_jefe;
                jefe.apellidos = o.apellidos_jefe;
                jefe.departamento.cod_departamento = o.id_departamento;
                return Ok(jefeBL.Create(jefe));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/jefes/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(jefeBL.Get(jefe)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/jefes/buscarrut")]
        public ActionResult Buscarrut(string rut)
        {
            try
            {
                jefe.rut = rut;
                return Ok(convert(jefeBL.GetById(jefe)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/jefes/buscarnombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                jefe.nombre = nombre;
                return Ok(convertList(jefeBL.GetQuery(jefe)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/jefes/eliminar")]
        public ActionResult Eliminar(JefesDTO o)
        {
            try
            {
                jefe.rut = o.rut;
                return Ok(jefeBL.Delete(jefe));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/jefes/actualizar")]
        public ActionResult Actualizar(JefesDTO o)
        {
            try
            {
                jefe.rut = o.rut;
                jefe.nombre = o.nombre_jefe;
                jefe.apellidos = o.apellidos_jefe;
                jefe.departamento.cod_departamento = o.id_departamento;
                return Ok(jefeBL.Update(jefe));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<JefesDTO> convertList(List<Jefes> lista)
        {
            List<JefesDTO> list = new List<JefesDTO>();
            foreach (var item in lista)
            {
                JefesDTO el = new JefesDTO(item.rut, item.nombre, item.apellidos, item.departamento.cod_departamento);
                list.Add(el);

            }
            return list;

        }
        private JefesDTO convert(Jefes item)
        {
            JefesDTO obj = new JefesDTO(item.rut, item.nombre, item.apellidos, item.departamento.cod_departamento);
            return obj;

        }
    }
}
