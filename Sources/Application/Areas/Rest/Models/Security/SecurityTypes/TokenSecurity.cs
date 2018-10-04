﻿using System.Net.Http;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security.SecurityTypes
{
    public class TokenSecurity : RestSecurity
    {
        private readonly string _encodedToken;

        internal TokenSecurity(string encodedToken)
        {
            Guard.ObjectNotNull(() => encodedToken);

            _encodedToken = encodedToken;
        }

        internal override void ApplySecurity(HttpRequestMessage requestMessage)
        {
            // https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient
            requestMessage.Headers.Add("Authorization", _encodedToken);
        }
    }
}