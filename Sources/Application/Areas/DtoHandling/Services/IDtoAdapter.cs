using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services
{
    public interface IDtoAdapter<TDto, TAggregateRoot, TId>
        where TDto : IDto<TId>
        where TAggregateRoot : AggregateRoot<TId>
    {
        TAggregateRoot Adapt(TDto dto);

        TDto Adapt(TAggregateRoot aggregateRoot);
    }
}