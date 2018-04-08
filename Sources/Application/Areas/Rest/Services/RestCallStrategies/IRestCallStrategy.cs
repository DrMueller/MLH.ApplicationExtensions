using System;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies
{
    internal interface IRestCallStrategy
    {
        RestCallMethodType MethodType { get; }

        Task<string> SendRequestAsync(Uri requestUri, object requestBody);
    }
}