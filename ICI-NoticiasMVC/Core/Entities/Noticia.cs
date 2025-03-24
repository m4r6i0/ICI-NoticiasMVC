namespace ICI_NoticiasMVC.Core.Entities
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; }

        public int UsuarioId { get; set; }      
        public Usuario Usuario { get; set; }  

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
 