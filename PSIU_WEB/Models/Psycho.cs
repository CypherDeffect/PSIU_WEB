using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIU_WEB.Models
{
    public class Psycho
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Especialização requerida.")]
        [Display(Name = "Especialização")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Número de licença requerido.")]
        [Display(Name = "Número de Licença")]
        public string CRP { get; set; }

        [Required(ErrorMessage = "E-mail requerido.")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone requerido.")]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

   
        public AppUser? User { get; set; }
    }

}
