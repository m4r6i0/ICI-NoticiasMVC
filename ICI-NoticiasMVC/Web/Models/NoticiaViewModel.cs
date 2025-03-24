using ICI_NoticiasMVC.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICI_NoticiasMVC.Web.Models
{
    public class NoticiaViewModel
    {
        public NoticiaDTO Noticia { get; set; } = new();
        public List<SelectListItem> AvailableTags { get; set; } = new();
        public List<SelectListItem> AvailableUsuarios { get; set; } = new();

    }
}

