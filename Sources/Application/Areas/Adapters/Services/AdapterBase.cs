using AutoMapper;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services
{
    public abstract class AdapterBase<TDto, TModel> : IAdapter<TDto, TModel>
    {
        private readonly IMapper _mapper;

        protected AdapterBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual TDto Adapt(TModel model)
        {
            return _mapper.Map<TDto>(model);
        }

        public abstract TModel Adapt(TDto dto);
    }
}