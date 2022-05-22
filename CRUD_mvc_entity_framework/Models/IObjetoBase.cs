using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_mvc.Models
{
    public interface IObjetoBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
