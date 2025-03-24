using ICI_NoticiasMVC.Application.DTOs;

namespace ICI_NoticiasMVC.Core.Interfaces
{
 
public interface INoticiaService
    {
        Task<IEnumerable<NoticiaDTO>> GetAllAsync();
        Task<NoticiaDTO?> GetByIdAsync(int id);
        Task CreateAsync(NoticiaDTO dto);
        Task UpdateAsync(NoticiaDTO dto);
        Task DeleteAsync(int id);
    }
}
