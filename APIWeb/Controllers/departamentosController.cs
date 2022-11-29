using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace APIWeb.Controllers
{
    [ApiController]
    public class departamentosController : ControllerBase
    {
        Departamentos dep = new Departamentos();
        DepartamentosBL depBL = new DepartamentosBL();
        ErrorResponse error;

        [HttpPost]
        [Route("Api/v1/departamentos/nuevo")]
        public ActionResult Create(DepartamentosDTO o)
        {
            try
            {
                dep.nombre_departamento = o.nombre_departamento;
                dep.direccion = o.direccion;
                dep.ciudad = o.ciudad;

                return Ok(depBL.Create(dep));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/departamentos/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(depBL.Get(dep)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/departamentos/buscardep")]
        public ActionResult Buscarrut(int cod_departamento)
        {
            try
            {
                dep.cod_departamento = cod_departamento;
                return Ok(convert(depBL.GetById(dep)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/departamentos/buscarnombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                dep.nombre_departamento = nombre;
                return Ok(convertList(depBL.GetQuery(dep)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/departamentos/eliminar")]
        public ActionResult Eliminar(DepartamentosDTO o)
        {
            try
            {
                dep.cod_departamento = o.cod_departamento;
                return Ok(depBL.Delete(dep));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/departamentos/actualizar")]
        public ActionResult Actualizar(DepartamentosDTO o)
        {
            try
            {
                dep.cod_departamento = o.cod_departamento;
                dep.nombre_departamento = o.nombre_departamento;
                dep.direccion = o.direccion;
                dep.ciudad = o.ciudad;
                return Ok(depBL.Update(dep));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }




        private List<DepartamentosDTO> convertList(List<Departamentos> lista)
        {
            List<DepartamentosDTO> list = new List<DepartamentosDTO>();
            foreach (var item in lista)
            {
                DepartamentosDTO el = new DepartamentosDTO(item.cod_departamento, item.nombre_departamento, item.direccion, item.ciudad);
                list.Add(el);
            }
            return list;
        }

        private DepartamentosDTO convert(Departamentos item)
        {
            DepartamentosDTO obj = new DepartamentosDTO(item.cod_departamento, item.nombre_departamento, item.direccion, item.ciudad);
            return obj;

        }
    }
}
