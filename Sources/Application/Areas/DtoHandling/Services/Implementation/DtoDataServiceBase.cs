using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Services.Implementation
{
    public abstract class DtoDataServiceBase<TDto, TAg, TId> : IDtoDataService<TDto, TId>
        where TAg : AggregateRoot<TId>
        where TDto : IDto<TId>
    {
        private readonly IDtoAdapter<TDto, TAg, TId> _dtoAdapter;
        private readonly IRepository<TAg, TId> _repository;

        protected DtoDataServiceBase(IRepository<TAg, TId> repository, IDtoAdapter<TDto, TAg, TId> dtoAdapter)
        {
            _repository = repository;
            _dtoAdapter = dtoAdapter;
        }

        public async Task DeleteAsync(TId id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<TDto>> LoadAllAsync()
        {
            var aggegateRoots = await _repository.LoadAllAsync();
            return aggegateRoots.Select(aggregateRoot => _dtoAdapter.Adapt(aggregateRoot)).ToList();
        }

        public async Task<TDto> LoadByIdAsync(TId id)
        {
            var aggregateRoot = await _repository.LoadByIdAsync(id);
            return _dtoAdapter.Adapt(aggregateRoot);
        }

        public async Task<TDto> SaveAsync(TDto dto)
        {
            var aggregateRoot = _dtoAdapter.Adapt(dto);
            var returnedAggregateRoot = await _repository.SaveAsync(aggregateRoot);
            var result = _dtoAdapter.Adapt(returnedAggregateRoot);
            return result;
        }
    }
}