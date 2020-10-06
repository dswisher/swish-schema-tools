
using System.Xml.Schema;

using SchemaTools.Visualization.Svg;

namespace SchemaTools.Visualization
{
    public interface IXsdTreeBuilder
    {
        AbstractSymbol Create(XmlSchemaSet schemaSet);
    }
}
