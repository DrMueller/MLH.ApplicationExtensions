namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services
{
    public interface IAdapterResolver
    {
        IAdapter<TDto, TModel> Resolve<TDto, TModel>();
    }
}