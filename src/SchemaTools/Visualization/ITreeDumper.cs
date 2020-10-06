
using System.Threading.Tasks;

using SchemaTools.Visualization.Svg;

namespace SchemaTools.Visualization
{
    public interface ITreeDumper
    {
        Task DumpAsync(AbstractSymbol root, string path);
    }
}
