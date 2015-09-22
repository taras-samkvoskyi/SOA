using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Core.Common.Contracts;
using Core.Common.Core;

namespace CarRental.Client.Proxies
{
    [Export(typeof(IServiceFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServiceFactory : IServiceFactory
    {
        T IServiceFactory.CreateClient<T>()
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
