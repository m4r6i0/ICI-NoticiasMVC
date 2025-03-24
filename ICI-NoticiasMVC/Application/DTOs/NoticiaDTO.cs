namespace ICI_NoticiasMVC.Application.DTOs
{
    public class NoticiaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; }

        public int UsuarioId { get; set; }
        public List<int> SelectedTagIds { get; set; } = new();

        public List<TagDTO> Tags { get; set; } = new();        
    }
}
