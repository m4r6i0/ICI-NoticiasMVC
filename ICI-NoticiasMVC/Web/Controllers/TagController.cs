using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICI_NoticiasMVC.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetAllAsync();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _tagService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null) return NotFound();

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TagDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            await _tagService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null) return NotFound();

            return View(tag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tagService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
