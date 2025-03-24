using AutoMapper;
using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Core.Entities;
using ICI_NoticiasMVC.Core.Interfaces;
using ICI_NoticiasMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ICI_NoticiasMVC.Application.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TagService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDTO>> GetAllAsync()
        {
            var tags = await _context.Tags.ToListAsync();
            return _mapper.Map<List<TagDTO>>(tags);
        }

        public async Task<TagDTO?> GetByIdAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            return tag == null ? null : _mapper.Map<TagDTO>(tag);
        }

        public async Task CreateAsync(TagDTO dto)
        {
            var tag = _mapper.Map<Tag>(dto);
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TagDTO dto)
        {
            var tag = await _context.Tags.FindAsync(dto.Id);
            if (tag == null) return;

            tag.Nome = dto.Nome;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}
