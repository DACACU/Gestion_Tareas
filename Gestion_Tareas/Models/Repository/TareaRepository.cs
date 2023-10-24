using Gestion_Tareas.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Tareas.Models.Repository
{
    public class TareaRepository : ITareaRepository

    {
        protected readonly DemoContext _demoContext;

        public TareaRepository(DemoContext demoContext) => _demoContext = demoContext;
        
        public IEnumerable<Tarea> GetAllTareas()
        {
            return _demoContext.Tareas.ToList();
        }
        public Tarea GetTareaById(int id)
        {
            return _demoContext.Tareas.Find(id);
        }
        public async Task<Tarea> CreateTareaAsync(Tarea tarea)
        {
            await _demoContext.Set<Tarea>().AddAsync(tarea);
            await _demoContext.SaveChangesAsync();
            return tarea;
        }
        public async Task<bool> UpdateTareaAsync(Tarea tarea)
        {
            _demoContext.Entry(tarea).State = EntityState.Modified;
            await _demoContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteTareaAsync(Tarea tarea)
        {
            if (tarea == null) 
            { 
                return false;
            }
            _demoContext.Set<Tarea>().Remove(tarea);
            await _demoContext.SaveChangesAsync();
            return true;
        }
    }
}
