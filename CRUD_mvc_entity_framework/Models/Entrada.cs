namespace CRUD_mvc.Models
{
    public class Entrada:IObjetoBase,IBaseEntradaSalida
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime HoraEntrada { get; set; }
        
        
    }
}
