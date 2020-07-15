using Dapper.Contrib.Extensions;

namespace WebApi_Core.Models
{
    [Table("dbo.Tipos")]
    public class Tipo
    {
        [Key]
        public int TipoId { get; set; }
        public string TipoNome { get; set; }

    }
}