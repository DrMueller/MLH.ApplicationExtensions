namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services
{
    public interface IAdapterResolver
    {
        IAdapter<TDto, TModel> ResolveByAdapteeTypes<TDto, TModel>();

        TAdapter ResolveByAdapterType<TAdapter>();
    }
}