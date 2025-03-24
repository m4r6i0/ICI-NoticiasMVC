using AutoMapper;
using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Core.Entities;
using ICI_NoticiasMVC.Core.Interfaces;
using ICI_NoticiasMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class NoticiaService : INoticiaService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public NoticiaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NoticiaDTO>> GetAllAsync()
    {
        var noticias = await _context.Noticias
            .Include(n => n.Tags)
            .ToListAsync();

        return _mapper.Map<List<NoticiaDTO>>(noticias);
    }

    public async Task<NoticiaDTO?> GetByIdAsync(int id)
    {
        var noticia = await _context.Noticias
            .Include(n => n.Tags)
            .FirstOrDefaultAsync(n => n.Id == id);

        return noticia == null ? null : _mapper.Map<NoticiaDTO>(noticia);
    }

    public async Task CreateAsync(NoticiaDTO dto)
    {
        dto.SelectedTagIds ??= new List<int>();

        var noticia = _mapper.Map<Noticia>(dto);

        noticia.Tags = await _context.Tags
            .Where(t => dto.SelectedTagIds.Contains(t.Id))
            .ToListAsync();

        _context.Noticias.Add(noticia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(NoticiaDTO dto)
    {
        dto.SelectedTagIds ??= new List<int>();

        var noticia = await _context.Noticias
            .Include(n => n.Tags)
            .FirstOrDefaultAsync(n => n.Id == dto.Id);

        if (noticia == null) return;

        noticia.Titulo = dto.Titulo;
        noticia.Conteudo = dto.Conteudo;
        noticia.DataPublicacao = dto.DataPublicacao;
        noticia.Tags.Clear();

        var tags = await _context.Tags
            .Where(t => dto.SelectedTagIds.Contains(t.Id))
            .ToListAsync();

        foreach (var tag in tags)
            noticia.Tags.Add(tag);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var noticia = await _context.Noticias.FindAsync(id);
        if (noticia != null)
        {
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
        }
    }
}
