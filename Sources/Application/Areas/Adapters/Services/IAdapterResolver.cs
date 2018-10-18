using System;
using System.Collections.Generic;
using System.Text;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services
{
    public interface IAdapterResolver
    {
        IAdapter<TDto, TModel> Resolve<TDto, TModel>();
    }
}
