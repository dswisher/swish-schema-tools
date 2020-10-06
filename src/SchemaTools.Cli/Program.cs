
using System;
using System.Threading.Tasks;

using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using SchemaTools.Cli.Options;
using SchemaTools.Visualization;
using Serilog;
using Serilog.Extensions.Logging;

namespace SchemaTools.Cli
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            // Set up logging
            var providers = new LoggerProviderCollection();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Providers(providers)
                .CreateLogger();

            // Set up the container
            var services = new ServiceCollection();

            services.AddLogging(l => l.AddSerilog());

            // TODO - move these to an extension method inside the class lib
            services.AddTransient<ISchemaVisualizer, SchemaVisualizer>();
            services.AddTransient<IXsdTreeBuilder, XsdTreeBuilder>();
            services.AddTransient<ITreeDumper, TreeDumper>();

            // Run it!
            using (var serviceProvider = services.BuildServiceProvider())
            {
                try
                {
                    var parsedArgs = Parser.Default.ParseArguments<GenerateOptions, VisualizeOptions>(args);

                    // Visualizing a schema
                    await parsedArgs.WithParsedAsync<VisualizeOptions>(options =>
                    {
                        var viz = serviceProvider.GetRequiredService<ISchemaVisualizer>();

                        viz.SchemaFilePath = options.SchemaFilePath;
                        viz.DumpFilePath = options.DumpFilePath;

                        return viz.VisualizeAsync();
                    });

                    // TODO - generation
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Unhandled exception in main.");
                }
            }

        }
    }
}
