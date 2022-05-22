namespace CRUD_mvc.Models
{
    public class Salida:IObjetoBase,IBaseEntradaSalida
    {
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }
        public Usuario Usuario { get ; set; }

        public DateTime HoraSalida { get; set; }

    }
}
