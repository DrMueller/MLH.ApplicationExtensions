namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models
{
    public abstract class DtoBase<TId>
    {
        public TId Id { get; set; }
    }
}