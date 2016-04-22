using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Modules
{
    public class StaticProxyModule : IHttpModule
    {
        void IHttpModule.Dispose()
        {
            throw new NotImplementedException();
        }

        void IHttpModule.Init(HttpApplication context)
        {
            throw new NotImplementedException();
        }
    }
}