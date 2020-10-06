
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using SchemaTools.Visualization.Svg;

namespace SchemaTools.Visualization
{
    public class TreeDumper : ITreeDumper
    {
        private readonly ILogger logger;

        public TreeDumper(ILogger<TreeDumper> logger)
        {
            this.logger = logger;
        }


        public async Task DumpAsync(AbstractSymbol root, string path)
        {
            logger.LogInformation("Dumping tree to {Path}.", path);

            using (var writer = new StreamWriter(path))
            {
                await DumpOneSymbolAsync(writer, root, 0);
            }
        }


        private async Task DumpOneSymbolAsync(TextWriter writer, AbstractSymbol symbol, int depth)
        {
            if (symbol == null)
            {
                return;
            }

            var text = symbol.ToString();
            var spaces = new string(' ', depth * 4);

            await writer.WriteLineAsync($"{spaces}{text}");

            foreach (var child in symbol.Children)
            {
                await DumpOneSymbolAsync(writer, child, depth + 1);
            }
        }
    }
}
