﻿using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class RestHeader
    {
        public string Name { get; }
        public string Value { get; }

        public RestHeader(string name, string value)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => value);

            Name = name;
            Value = value;
        }
    }
}