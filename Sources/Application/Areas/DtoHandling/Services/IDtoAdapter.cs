using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services
{
    public interface IDtoAdapter<TDto, TAggregateRoot, TId> : IAdapter<TDto, TAggregateRoot>
        where TDto : DtoBase<TId>
        where TAggregateRoot : AggregateRoot<TId>
    {
    }
}