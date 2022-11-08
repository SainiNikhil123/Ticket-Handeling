using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Logger
{
    [ProviderAlias("TicketProjectFile")]
    public class TicketProjectFileLoggerProvider : ILoggerProvider
    {
        public readonly TicketProjectFileLoggerOptions options;
        public TicketProjectFileLoggerProvider(IOptions<TicketProjectFileLoggerOptions> _options)
        {
            options = _options.Value;

            if(!Directory.Exists(options.FolderPath))
            {
                Directory.CreateDirectory(options.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TicketProjectFileLogger(this);
        }

        public void Dispose()
        {
        }
    }
}
