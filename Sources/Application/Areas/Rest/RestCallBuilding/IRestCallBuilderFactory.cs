using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding
{
    public interface IRestCallBuilderFactory
    {
        IRestCallBuilder StartBuilding(Uri basePath, RestCallMethodType methodType = RestCallMethodType.Get);
    }
}
