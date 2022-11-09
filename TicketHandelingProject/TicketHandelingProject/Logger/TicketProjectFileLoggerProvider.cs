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
        public readonly TicketProjectFileLoggerOptions Options;
        public TicketProjectFileLoggerProvider(IOptions<TicketProjectFileLoggerOptions> _options)
        {
            Options = _options.Value;

            if(!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
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
