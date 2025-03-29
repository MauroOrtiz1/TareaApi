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
        
        // GET api/tasks/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // Respuesta 200 OK cuando la operación tiene éxito
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Respuesta 404 Not Found si la tarea no existe
        public IActionResult ObtenerTareaPorId(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                return NotFound(); // Devuelve un 404 si la tarea no se encuentra
            }
            return Ok(tarea); // Devuelve la tarea encontrada en formato JSON
        }
        // POST api/tasks
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)] // Respuesta 201 Created cuando la tarea es creada
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Respuesta 400 si hay un error en la petición
        public IActionResult CrearTarea([FromBody] Tarea nuevaTarea)
        {
            if (nuevaTarea == null || string.IsNullOrEmpty(nuevaTarea.Titulo) || string.IsNullOrEmpty(nuevaTarea.Estado))
            {
                return BadRequest("El título y el estado son obligatorios."); // Validación simple
            }

            nuevaTarea.Id = tareas.Max(t => t.Id) + 1; // Asigna un nuevo ID
            tareas.Add(nuevaTarea); // Agrega la nueva tarea a la lista

            return CreatedAtAction(nameof(ObtenerTareaPorId), new { id = nuevaTarea.Id }, nuevaTarea); // Devuelve el 201 Created
        }
    }
}
// Esto es una prueba
