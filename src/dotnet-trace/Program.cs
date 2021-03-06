using System;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Internal.Utilities;

namespace Microsoft.Diagnostics.Tools.Trace
{
    [Command(Name = "dotnet-trace", Description = "Collects event traces from .NET processes")]
    [Subcommand(SourcesCommand.Name, typeof(SourcesCommand))]
    [Subcommand(CollectCommand.Name, typeof(CollectCommand))]
    internal class Program
    {
        private static int Main(string[] args)
        {
            DebugUtil.WaitForDebuggerIfRequested(ref args);

            try
            {
                return CommandLineApplication.Execute<Program>(args);
            }
            catch (OperationCanceledException)
            {
                return 0;
            }
        }

        public int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return 0;
        }
    }
}
