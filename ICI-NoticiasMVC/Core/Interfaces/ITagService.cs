using ICI_NoticiasMVC.Application.DTOs;

namespace ICI_NoticiasMVC.Core.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetAllAsync();
        Task<TagDTO?> GetByIdAsync(int id);
        Task CreateAsync(TagDTO tag);
        Task UpdateAsync(TagDTO tag);
        Task DeleteAsync(int id);
    }
}
