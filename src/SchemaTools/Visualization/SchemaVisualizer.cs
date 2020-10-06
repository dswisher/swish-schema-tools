
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

using Microsoft.Extensions.Logging;

namespace SchemaTools.Visualization
{
    public class SchemaVisualizer : ISchemaVisualizer
    {
        private readonly IXsdTreeBuilder treeBuilder;
        private readonly ITreeDumper treeDumper;
        private readonly ILogger logger;

        public SchemaVisualizer(IXsdTreeBuilder treeBuilder,
                                ITreeDumper treeDumper,
                                ILogger<SchemaVisualizer> logger)
        {
            this.treeBuilder = treeBuilder;
            this.treeDumper = treeDumper;
            this.logger = logger;
        }


        public string SchemaFilePath { get; set; }
        public string DumpFilePath { get; set; }


        public async Task VisualizeAsync()
        {
            // Load the specified schema file
            var schemaSet = new XmlSchemaSet();

            AddSchemaToSet(schemaSet, SchemaFilePath);

            schemaSet.Compile();

            // Build a tree of graphical symbols that represents the schema
            var tree = treeBuilder.Create(schemaSet);

            // Dump the tree (if desired) - useful for debugging
            if (!string.IsNullOrEmpty(DumpFilePath))
            {
                await treeDumper.DumpAsync(tree, DumpFilePath);
            }

            // "Draw" the tree to an SVG (positioning, etc).
            // TODO - draw the diagram

            // Save the diagram to the specified file
            // TODO - save the diagram

            logger.LogWarning("VisualizeAsync is not yet implemented!");
        }


        private void AddSchemaToSet(XmlSchemaSet set, string path)
        {
            logger.LogInformation("Loading XmlSchema from {Path}.", path);

            // Load the schema, and add it to the set.
            XmlSchema schema;

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var reader = XmlReader.Create(stream))
            {
                schema = XmlSchema.Read(reader, null);

                set.Add(schema);
            }

            // Process any includes that the schema might contain.
            foreach (XmlSchemaInclude include in schema.Includes)
            {
                var includePath = Path.Combine(Path.GetDirectoryName(path), include.SchemaLocation);

                AddSchemaToSet(set, includePath);
            }
        }
    }
}
