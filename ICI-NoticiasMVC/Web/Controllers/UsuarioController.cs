using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICI_NoticiasMVC.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View(new UsuarioDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _usuarioService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _usuarioService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
