using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Newtonsoft.Json;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class RestProxy : IRestProxy
    {
        private readonly IRestCallStrategy[] _restCallStrategies;

        public RestProxy(IRestCallStrategy[] restCallStrategies)
        {
            _restCallStrategies = restCallStrategies;
        }

        public async Task<T> PerformCallAsync<T>(RestCall restCall)
        {
            Guard.ObjectNotNull(() => restCall);

            var requestUri = new Uri(restCall.BaseUri, restCall.ResourcePath);

            var callStrategy = _restCallStrategies.FirstOrDefault(f => f.MethodType == restCall.MethodType);
            if (callStrategy == null)
            {
                throw new ArgumentException($"Call method {restCall.MethodType} is not recognized.");
            }

            var resultContent = await callStrategy.SendRequestAsync(requestUri, restCall.Body);
            var result = ParseResultContent<T>(resultContent);
            return result;
        }

        private static T ParseResultContent<T>(string content)
        {
            if (string.IsNullOrEmpty(content) || content == "[]")
            {
                return default(T);
            }

            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
    }
}