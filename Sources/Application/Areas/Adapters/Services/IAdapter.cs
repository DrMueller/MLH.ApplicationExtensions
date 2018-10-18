namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services
{
    public interface IAdapter<TDto, TModel>
    {
        TDto Adapt(TModel model);

        TModel Adapt(TDto dto);
    }
}