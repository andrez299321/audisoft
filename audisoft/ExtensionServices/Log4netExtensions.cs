using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace audisoft.ExtensionServices
{
    public static class Log4netExtensions
    {
        public static void AddLog4net(this IServiceCollection services)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            services.AddSingleton(LogManager.GetLogger(typeof(Program)));
        }
    }
}
