using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIU_WEB.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Resume { get; set; }

        public string HtmlContent { get; set; }

        public int PsychoId { get; set; }

        [ForeignKey("PsychoId")]
        public string Psycho { get; set; }

        public List<ContentCategory> ContentsCategories { get; set; }
                                     //Entidade
          

    }
}
