using Gestion_Tareas.Models.Data;
using Gestion_Tareas.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Tareas.Controllers
{
    [ApiController]
    [Route("[api/tarea]")]
    public class TareaController : Controller
    {
        private ITareaRepository _tareaRepository;

        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }


        // GET: TareaController
        [HttpGet]
        [ActionName(nameof(GetTareasAsync))]
        public IEnumerable<Tarea> GetTareasAsync()
        {
            return _tareaRepository.GetAllTareas();
        }

        // GET: TareaController/Details/5
        [HttpGet("{id_tarea}")]
        [ActionName(nameof(GetTareasById))]
        public ActionResult<Tarea> GetTareasById(int id)
        {
            var tareaByID = _tareaRepository.GetTareaById(id);
            if(tareaByID == null)
            {
                return new NotFoundResult();
            }
            return tareaByID;
        }

        // GET: TareaController/Create

        [HttpPost]
        [ActionName(nameof(CreateTareaAsync))]
        public async Task<ActionResult<Tarea>> CreateTareaAsync(Tarea tarea)
        {
            await _tareaRepository.CreateTareaAsync(tarea);
            return CreatedAtAction(nameof(GetTareasById), new {id_tarea = tarea.id_tarea}, tarea);
        }

        [HttpPut]
        [ActionName(nameof(UpdateTarea))]
        public async Task<ActionResult> UpdateTarea(int id_tarea, Tarea tarea)
        {
            if (id_tarea != tarea.id_tarea) 
            {
                return BadRequest();
            }
            await _tareaRepository.UpdateTareaAsync(tarea);
            return Ok();
        }
        [HttpDelete]
        [ActionName(nameof(DeleteTareas))]
        public async Task<IActionResult> DeleteTareas(int id_tarea)
        {
            var tarea = _tareaRepository.GetTareaById(id_tarea);
            if (tarea == null)
            {
                return NotFound();
            }
            await _tareaRepository.DeleteTareaAsync(tarea);
            return NoContent();
        }
    }
}
