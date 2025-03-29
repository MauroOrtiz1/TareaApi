using ActividadApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActividadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<Tarea> tareas = new List<Tarea>
        {
            new Tarea { Id = 1, Titulo = "Tarea1", Descripcion = "Metodo GET API", Estado = "Pendiente" },
            new Tarea { Id = 2, Titulo = "Tarea2", Descripcion = "Terminar Laboratorio", Estado = "Completado" }
        };

        // GET api/tasks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // Respuesta 200 OK cuando la operación tiene éxito
        public IActionResult ObtenerTodasLasTareas()
        {
            return Ok(tareas); // Devuelve todas las tareas en formato JSON
        }
    }
}

