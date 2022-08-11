using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.Areas.Common.TestData.Services
{
    public static class TestModelFactory
    {
        public static List<T> CreateSome<T>(int amount)
        {
            var result = new List<T>();

            for (var i = 0; i < amount; i++)
            {
                result.Add(CreateWithRandomValues<T>());
            }

            return result;
        }

        private static object CreateRandomValueForProperty(PropertyInfo property)
        {
            var propertyType = property.PropertyType;

            if (propertyType == typeof(DateTime))
            {
                return RandomValueFactory.CreateDateTime();
            }

            if (propertyType == typeof(long))
            {
                return RandomValueFactory.CreateLong();
            }

            if (propertyType.IsEnum)
            {
                return RandomValueFactory.CreateEnum(propertyType);
            }

            return RandomValueFactory.CreateString(20);
        }

        private static T CreateWithRandomValues<T>()
        {
            var instance = Activator.CreateInstance<T>();
            var writablePropertyInfos = instance!.GetType().GetProperties().Where(f => f.CanWrite);

            foreach (var writableProperty in writablePropertyInfos)
            {
                writableProperty.SetValue(instance, CreateRandomValueForProperty(writableProperty));
            }

            return instance;
        }
    }
}