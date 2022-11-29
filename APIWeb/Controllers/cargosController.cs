using Microsoft.AspNetCore.Mvc;
using Modelos.Mantenedores;
using Negocio.Mantenedores;

namespace APIWeb.Controllers
{
    [ApiController]
    public class cargosController : ControllerBase
    {

        Cargos carg = new Cargos();
        CargosBL cargBL = new CargosBL();
        ErrorResponse error;
        [HttpPost]
        [Route("api/v1/cargos/nuevocarago")]
        public ActionResult Create(CargosDTO o)
        {
            try
            {
                carg.cod_cargo = o.cod_cargo;
                carg.nombre = o.nombre_cargo;
                return Ok(cargBL.Create(carg));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpGet]
        [Route("api/v1/cargos/listar")]
        public ActionResult Listar()
        {
            try
            {
                return Ok(convertList(cargBL.Get(carg)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/cargos/buscar")]
        public ActionResult Buscar(int id)
        {
            try
            {
                carg.cod_cargo = id;
                return Ok(convert(cargBL.GetById(carg)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }
        [HttpGet]
        [Route("api/v1/cargos/buscarnombre")]
        public ActionResult BuscarNombre(string nombre)
        {
            try
            {
                carg.nombre = nombre;
                return Ok(convertList(cargBL.GetQuery(carg)));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpDelete]
        [Route("api/v1/cargos/eliminar")]
        public ActionResult Eliminar(CargosDTO o)
        {
            try
            {
                carg.cod_cargo = o.cod_cargo;
                return Ok(cargBL.Delete(carg));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        [HttpPut]
        [Route("api/v1/cargos/actualizar")]
        public ActionResult Actualizar(CargosDTO o)
        {
            try
            {
                carg.cod_cargo = o.cod_cargo;
                carg.nombre = o.nombre_cargo;
                return Ok(cargBL.Update(carg));
            }
            catch (Exception ex)
            {
                error = new ErrorResponse(ex);
                return StatusCode(500, error);
            }

        }

        private List<CargosDTO> convertList(List<Cargos> lista)
        {
            List<CargosDTO> list = new List<CargosDTO>();
            foreach (var item in lista)
            {
                CargosDTO el = new CargosDTO(item.cod_cargo, item.nombre);
                list.Add(el);

            }
            return list;

        }
        private CargosDTO convert(Cargos item)
        {
            CargosDTO obj = new CargosDTO(item.cod_cargo, item.nombre);
            return obj;

        }
    }
}
