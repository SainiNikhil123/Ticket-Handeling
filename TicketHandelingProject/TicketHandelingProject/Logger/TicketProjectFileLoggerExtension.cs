
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Logger
{
    public static class TicketProjectFileLoggerExtension
    {
        public static ILoggingBuilder AddTicketProjectFileLogger(this ILoggingBuilder builder, Action<TicketProjectFileLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, TicketProjectFileLoggerProvider>();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
