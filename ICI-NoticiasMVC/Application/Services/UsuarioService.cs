using AutoMapper;
using ICI_NoticiasMVC.Application.DTOs;
using ICI_NoticiasMVC.Core.Entities;
using ICI_NoticiasMVC.Core.Interfaces;
using ICI_NoticiasMVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ICI_NoticiasMVC.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO?> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task CreateAsync(UsuarioDTO dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.Id);
            if (usuario == null) return;

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
