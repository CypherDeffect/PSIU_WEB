using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIU_WEB.Models
{
    public class Midia
    {
        // Atributos 

        [Key] //Chave Primária 
        public int Id { get; set; }
        public string? URL { get; set; }
        public int? TipoMidia { get; set; }

    }


}