
using System.Threading.Tasks;

namespace SchemaTools.Visualization
{
    public interface ISchemaVisualizer
    {
        string SchemaFilePath { get; set; }
        string DumpFilePath { get; set; }

        Task VisualizeAsync();
    }
}
