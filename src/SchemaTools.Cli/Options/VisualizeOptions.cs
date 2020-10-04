
using CommandLine;

namespace SchemaTools.Cli.Options
{
    [Verb("visualize", HelpText = "Create an SVG to visualize a schema.")]
    public class VisualizeOptions
    {
        [Option("schema", HelpText = "The file containing the schema to visualize.")]
        public string SchemaFile { get; set; }
    }
}
