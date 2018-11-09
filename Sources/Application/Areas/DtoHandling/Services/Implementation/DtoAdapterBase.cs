using AutoMapper;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services.Implementation
{
    public abstract class DtoAdapterBase<TDto, TAggregateRoot, TId> : AdapterBase<TDto, TAggregateRoot>, IDtoAdapter<TDto, TAggregateRoot, TId>
        where TDto : DtoBase<TId>
        where TAggregateRoot : AggregateRoot<TId>
    {
        protected DtoAdapterBase(IMapper mapper) : base(mapper)
        {
        }
    }
}