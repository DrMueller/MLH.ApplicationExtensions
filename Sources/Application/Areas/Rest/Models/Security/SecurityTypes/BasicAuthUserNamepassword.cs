﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security.SecurityTypes
{
    public class BasicAuthUserNamePassword : SecurityOptions
    {
        private readonly string _password;
        private readonly string _userName;

        public BasicAuthUserNamePassword(string userName, string password)
        {
            Guard.StringNotNullOrEmpty(() => userName);
            Guard.StringNotNullOrEmpty(() => password);

            _userName = userName;
            _password = password;
        }

        internal override void ApplySecurity(HttpRequestMessage requestMessage)
        {
            var basicAuthStr = $"{_userName}:{_password}";
            var encodedCredentials = Convert.ToBase64String(Encoding.Default.GetBytes(basicAuthStr));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
        }
    }
}