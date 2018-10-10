using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services
{
    public interface IDtoDataService<TDto, TId>
    {
        Task DeleteAsync(TId id);

        Task<IReadOnlyCollection<TDto>> LoadAllAsync();

        Task<TDto> LoadByIdAsync(TId id);

        Task<TDto> SaveAsync(TDto dto);
    }
}