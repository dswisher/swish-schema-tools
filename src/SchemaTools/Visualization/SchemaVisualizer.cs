
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace SchemaTools.Visualization
{
    public class SchemaVisualizer : ISchemaVisualizer
    {
        private readonly ILogger logger;

        public SchemaVisualizer(ILogger<SchemaVisualizer> logger)
        {
            this.logger = logger;
        }


        public async Task VisualizeAsync()
        {
            logger.LogWarning("VisualizeAsync is not yet implemented!");

            // TODO - implement me!
            await Task.CompletedTask;
        }
    }
}
