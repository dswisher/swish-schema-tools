
using System.Xml.Schema;

using SchemaTools.Visualization.Svg;

namespace SchemaTools.Visualization
{
    public class XsdTreeBuilder : IXsdTreeBuilder
    {
        public AbstractSymbol Create(XmlSchemaSet schemaSet)
        {
            // The tree always starts with the schema symbol. Create it.
            var root = new SchemaSymbol();

            // Go through all the elements and add their symbols as children of the root.
            foreach (XmlSchemaElement element in schemaSet.GlobalElements.Values)
            {
                ProcessElement(root, element);
            }

            // Return what we've got
            return root;
        }


        private void ProcessElement(AbstractSymbol parent, XmlSchemaElement element)
        {
            XmlSchemaType schemaType = element.ElementSchemaType;

            var symbol = new ElementSymbol
            {
                Name = element.Name,
                Type = schemaType.Name

                // TODO - namespace, type, cardinality, nillable, abstract, substitution
            };

            parent.AddChild(symbol);

            // TODO - handle "ref" and complex type entries
        }
    }
}
