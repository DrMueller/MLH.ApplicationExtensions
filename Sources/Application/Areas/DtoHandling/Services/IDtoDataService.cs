using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services
{
    public interface IDtoDataService<TDto, TId>
        where TDto : DtoBase<TId>
    {
        Task DeleteAsync(TId id);

        Task<IReadOnlyCollection<TDto>> LoadAllAsync();

        Task<TDto> LoadByIdAsync(TId id);

        Task<TDto> SaveAsync(TDto dto);
    }
}