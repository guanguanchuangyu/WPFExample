using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace G2CyHome.Wpf.Datas.Logger
{
    public static class Log4NetLoggerFactoryExtensions
    {
        public static ILoggingBuilder AddLog4Net(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, Log4NetLoggerProvider>());
            return builder;
        }
    }
}
