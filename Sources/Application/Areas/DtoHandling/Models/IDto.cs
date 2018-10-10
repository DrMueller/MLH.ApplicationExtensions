using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DtoHandling.Models
{
    [SuppressMessage("Microsoft.Usage", "CA1040: Avoid empty interfaces", Justification = "Marker Interface")]
    public interface IDto<TId>
    {
    }
}