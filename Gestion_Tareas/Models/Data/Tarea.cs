namespace Gestion_Tareas.Models.Data
{
    public class Tarea
    {
        public int id_tarea {  get; set; }
        public string titulo_tarea { get; set; }
        public string descripcion_tarea { get; set; }
        public DateTime fecha_creacion_tarea { get; set; }
        public DateOnly fecha_vencimiento_tarea { get; set; }
        public string estado_tarea { get; set; }
            

    }
}
