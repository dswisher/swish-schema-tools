
using CommandLine;

namespace SchemaTools.Cli.Options
{
    [Verb("generate", HelpText = "Generate a schema from one or more classes.")]
    public class GenerateOptions
    {
        [Option("schema", HelpText = "The output schema file to create.")]
        public string SchemaFilePath { get; set; }
    }
}
