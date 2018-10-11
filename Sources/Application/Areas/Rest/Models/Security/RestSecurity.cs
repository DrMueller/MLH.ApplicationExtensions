﻿using System.Net.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security.SecurityTypes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security
{
    public abstract class RestSecurity
    {
        internal abstract void ApplySecurity(HttpRequestMessage requestMessage);

        public static RestSecurity CreateAnonymous()
        {
            return new Anonymouss();
        }

        public static RestSecurity CreateBasicAuthentication(string userName, string password)
        {
            return new BasicAuthentication(userName, password);
        }

        public static RestSecurity CreateTokenSecurity(string encodedToken)
        {
            return new TokenSecurity(encodedToken);
        }
    }
}