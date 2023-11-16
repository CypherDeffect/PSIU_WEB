using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIU_WEB.Models
{
    public class ContentMidia
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ConteudoId")]
        public int Conteudo { get; set; }

        [ForeignKey("MidiaId")]

        public int Midia {get; set; }

    }
}
