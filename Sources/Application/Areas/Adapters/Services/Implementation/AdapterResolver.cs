using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services.Implementation
{
    public class AdapterResolver : IAdapterResolver
    {
        private readonly IServiceLocator _serviceLocator;

        public AdapterResolver(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IAdapter<TDto, TModel> ResolveByAdapteeTypes<TDto, TModel>()
        {
            return _serviceLocator.GetService<IAdapter<TDto, TModel>>();
        }

        public TAdapter ResolveByAdapterType<TAdapter>()
        {
            return _serviceLocator.GetService<TAdapter>();
        }
    }
}