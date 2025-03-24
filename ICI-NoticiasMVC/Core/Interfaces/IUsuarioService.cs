using ICI_NoticiasMVC.Application.DTOs;

namespace ICI_NoticiasMVC.Core.Interfaces
{
 
public interface IUsuarioService
    {

        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO?> GetByIdAsync(int id);
        Task CreateAsync(UsuarioDTO dto);
        Task UpdateAsync(UsuarioDTO dto);
        Task DeleteAsync(int id);
    }
}

