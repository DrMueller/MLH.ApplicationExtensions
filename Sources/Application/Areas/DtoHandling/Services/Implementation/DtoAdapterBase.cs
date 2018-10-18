using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services.Implementation
{
    public abstract class DtoAdapterBase<TDto, TAggregateRoot, TId> : IDtoAdapter<TDto, TAggregateRoot, TId>
        where TDto : DtoBase<TId>
        where TAggregateRoot : AggregateRoot<TId>
    {
        private readonly IMapper _mapper;

        protected DtoAdapterBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract TAggregateRoot Adapt(TDto dto);

        public virtual TDto Adapt(TAggregateRoot aggregateRoot)
        {
            return _mapper.Map<TDto>(aggregateRoot);
        }
    }
}