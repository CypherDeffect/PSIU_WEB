using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIU_WEB.Models
{
    public class Category { 

        // Atributos 

        [Key] //Chave Primária 
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")] // Chave Estrangeira

        public Category? Parent { get; set; }

        public List<ContentCategory>? ContentsCategories { get; set; } //<itens da lista> vários categories na lista


    }
}