using Gestion_Tareas.Models.Data;

namespace Gestion_Tareas.Models.Repository
{
    public interface ITareaRepository
    {
        Task<Tarea> CreateTareaAsync(Tarea tarea);
        Task<bool> DeleteTareaAsync(Tarea tarea);
        Tarea GetTareaById(int id);
        IEnumerable<Tarea> GetAllTareas();
        Task<bool> UpdateTareaAsync(Tarea tarea);
    }
}
