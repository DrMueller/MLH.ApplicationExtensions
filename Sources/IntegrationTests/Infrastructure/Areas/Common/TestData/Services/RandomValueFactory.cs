using System;
using System.Linq;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.Areas.Common.TestData.Services
{
    public static class RandomValueFactory
    {
        private static readonly Random _random = new Random();

        public static DateTime CreateDateTime()
        {
            var randomYear = _random.Next(1900, DateTime.Now.Year);
            var randomMonth = _random.Next(1, 13);
            var randomDay = _random.Next(1, 28);

            var result = new DateTime(randomYear, randomMonth, randomDay);
            return result;
        }

        public static object CreateEnum(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var values = enumType.GetEnumValues().Cast<object>().ToList();
            var randomIndex = _random.Next(0, values.Count - 1);
            return values.ElementAt(randomIndex);
        }

        public static long CreateLong() => _random.Next();

        public static string CreateString(int stringLength)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(
                Enumerable.Repeat(Chars, stringLength)
                    .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}