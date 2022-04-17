using BussinesLayer.EmpleadoBR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Object;
using Object.Empleado;
using System;
using System.Collections.Generic;

namespace ApiContpaqi.Controllers
{
    [Produces("application/json")]
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private Response response = new Response();
        public IConfiguration Configuration { get; }

        public EmpleadoController(IConfiguration configuration)// => Configuration = configuration;
        {
            Configuration = configuration;

        }
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getEmpleado")]
        public IActionResult getEmpleado(string nombre = null, string rfc = null, int? estatusId=null)
        {
            try
            {
                List<EmpleadoObj> lst = new List<EmpleadoObj>();
                EmpleadoObj obj = new EmpleadoObj();
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);

                obj.nombre = nombre;
                obj.rfc = rfc;
                obj.estatusId = estatusId;
                lst = empl.getEmpleado(obj);


                if (lst != null)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Data.Info.result = lst;
                }
                else
                {
                    response.IsCorrect = "false";
                }

                return Ok(response); ;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        [HttpGet]
        [Route("getEmpleadoXId")]
        public IActionResult getEmpleadoXId(int empleadoId)
        {
            try
            {
                EmpleadoObj lst = new EmpleadoObj();
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                lst = empl.getEmpleadoXId(empleadoId);

                if (lst != null)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Data.Info.result = lst;
                }
                else
                {
                    response.IsCorrect = "false";
                }

                return Ok(response); ;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        [HttpGet]
        [Route("getGenero")]
        public IActionResult getGenero()
        {
            try
            {
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                lst = empl.getGenero();


                if (lst != null)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Data.Info.result = lst;
                }
                else
                {
                    response.IsCorrect = "false";
                }

                return Ok(response); ;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        [HttpGet]
        [Route("getEstadoCivil")]
        public IActionResult getEstadoCivil()
        {
            try
            {
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                lst = empl.getEstadoCivil();


                if (lst != null)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Data.Info.result = lst;
                }
                else
                {
                    response.IsCorrect = "false";
                }

                return Ok(response); ;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        [HttpGet]
        [Route("getPuesto")]
        public IActionResult getPuesto()
        {
            try
            {
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                lst = empl.getPuesto();


                if (lst != null)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Data.Info.result = lst;
                }
                else
                {
                    response.IsCorrect = "false";
                }

                return Ok(response); ;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        [HttpGet]
        [Route("getEstatus")]
        public IActionResult getEstatus()
        {
            try
            {
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                lst = empl.getEstatus();


                if (lst != null)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Data.Info.result = lst;
                }
                else
                {
                    response.IsCorrect = "false";
                }

                return Ok(response); ;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        [HttpPost]
        [Route("setEmpleado")]
        public IActionResult setEmpleado(EmpleadoObj empleado)
        {
            try
            {
                int r = 0;
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                r = empl.setEmpleado(empleado);


                if (r >= 0)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Message = "Empleado insertado con exito.";
                }
                else
                {
                    response.IsCorrect = "false";
                    response.Message = "Error al insertar empleado.";
                }

                return Ok(response); 
            }
            catch (Exception ex)
            {
                response.IsCorrect = "false";
                response.Message = "Error al insertar empleado. " + ex.Message;
                throw;
            }
        }

        [HttpPost]
        [Route("updateEmpleado")]
        public IActionResult updateEmpleado(EmpleadoObj empleado)
        {
            try
            {
                int r = 0;
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                r = empl.updateEmpleado(empleado);


                if (r >= 0)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Message = "Empleado actualizado con exito.";
                }
                else
                {
                    response.IsCorrect = "false";
                    response.Message = "Error al actualizar empleado.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsCorrect = "false";
                response.Message = "Error al actualizar empleado. " + ex.Message;
                throw;
            }
        }

        [HttpPost]
        [Route("deleteEmpleado")]
        public IActionResult deleteEmpleado(EmpleadoObj empleado)
        {
            try
            {
                int r = 0;
                EmpleadoBR empl = new EmpleadoBR(new Helper.GetConnection(Configuration).GetConfigurationString);
                r = empl.deleteEmpleado(empleado);


                if (r >= 0)
                {
                    response.IsCorrect = "true";
                    response.Data = new Data();
                    response.Data.Info = new Info();
                    response.Message = "Empleado actualizado con exito.";
                }
                else
                {
                    response.IsCorrect = "false";
                    response.Message = "Error al actualizar empleado.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsCorrect = "false";
                response.Message = "Error al actualizar empleado. " + ex.Message;
                throw;
            }
        }
       
    }
}
