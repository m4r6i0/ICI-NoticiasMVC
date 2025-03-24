using System.ComponentModel.DataAnnotations;

namespace ICI_NoticiasMVC.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public ICollection<Noticia> Noticias { get; set; } = new List<Noticia>();
    }
}
