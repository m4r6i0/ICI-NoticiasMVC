using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Application.Services;
using ICI_NoticiasMVC.Core.Interfaces;
using ICI_NoticiasMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICI_NoticiasMVC.Web.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;
        private readonly IUsuarioService _usuarioService;
        private readonly ITagService _tagService;

        public NoticiaController(INoticiaService noticiaService, ITagService tagService, IUsuarioService usuarioService)
        {
            _noticiaService = noticiaService;
            _tagService = tagService;
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var noticias = await _noticiaService.GetAllAsync();
            return View(noticias);
        }

        public async Task<IActionResult> Create()
        {
            var dto = new NoticiaDTO();
            dto.DataPublicacao = DateTime.Today;
            var tags = await _tagService.GetAllAsync();
            var usuarios = await _usuarioService.GetAllAsync();


            var viewModel = new NoticiaViewModel
            {
                Noticia = dto,
                AvailableTags = tags.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome
                }).ToList(),
                AvailableUsuarios = usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.Nome }).ToList()

            };

            return PartialView("_Form", viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _noticiaService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var tags = await _tagService.GetAllAsync();
            var usuarios = await _usuarioService.GetAllAsync();


            var viewModel = new NoticiaViewModel
            {
                Noticia = dto,
                AvailableTags = tags.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome,
                    Selected = dto.SelectedTagIds.Contains(t.Id)
                }).ToList(),
                AvailableUsuarios = usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.Nome }).ToList()

            };

            return PartialView("_Form", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NoticiaViewModel viewModel)
        {
            var dto = viewModel.Noticia;

            if (dto.Id == 0)
                await _noticiaService.CreateAsync(dto);
            else
                await _noticiaService.UpdateAsync(dto);

            return Ok();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _noticiaService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var tags = await _tagService.GetAllAsync();

            var viewModel = new NoticiaViewModel
            {
                Noticia = dto,
                AvailableTags = tags.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome,
                    Selected = dto.SelectedTagIds.Contains(t.Id)
                }).ToList()
            };

            return View(viewModel);
        }


        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _noticiaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
