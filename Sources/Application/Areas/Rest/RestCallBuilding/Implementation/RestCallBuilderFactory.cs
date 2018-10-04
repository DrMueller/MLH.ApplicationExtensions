using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding.NewFolder
{
    internal class RestCallBuilderFactory : IRestCallBuilderFactory
    {
        public IRestCallBuilder StartBuilding(Uri basePath, RestCallMethodType methodType = RestCallMethodType.Get)
        {
            return new RestCallBuilder(basePath, methodType);
        }
    }
}