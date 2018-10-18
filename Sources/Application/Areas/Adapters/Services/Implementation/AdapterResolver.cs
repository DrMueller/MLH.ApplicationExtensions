using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services.Implementation
{
    public class AdapterResolver : IAdapterResolver
    {
        private readonly IProvisioningService _provosioningService;

        public AdapterResolver(IProvisioningService provosioningService)
        {
            _provosioningService = provosioningService;
        }

        public IAdapter<TDto, TModel> Resolve<TDto, TModel>()
        {
            return _provosioningService.GetService<IAdapter<TDto, TModel>>();
        }
    }
}