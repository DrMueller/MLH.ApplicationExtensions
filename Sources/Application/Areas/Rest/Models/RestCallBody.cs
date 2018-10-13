using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class RestCallBody
    {
        public string MediaType { get; }
        public object Payload { get; }

        public RestCallBody(object payload, string mediaType = "application/json")
        {
            Guard.ObjectNotNull(() => payload);
            Guard.StringNotNullOrEmpty(() => mediaType);

            Payload = payload;
            MediaType = mediaType;
        }
    }
}