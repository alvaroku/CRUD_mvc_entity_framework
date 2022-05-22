namespace CRUD_mvc.Models
{
    public interface IBaseEntradaSalida
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
