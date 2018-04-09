using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services
{
    public interface IRestProxy
    {
        Task<T> PerformCallAsync<T>(RestCall restCall);
    }
}