
using CommandLine;

namespace SchemaTools.Cli.Options
{
    [Verb("visualize", HelpText = "Create an SVG to visualize a schema.")]
    public class VisualizeOptions
    {
        [Option("schema", Required = true, HelpText = "The file containing the schema to visualize.")]
        public string SchemaFilePath { get; set; }

        [Option("dump", HelpText = "Location of a file where debug info is written.")]
        public string DumpFilePath { get; set; }
    }
}
