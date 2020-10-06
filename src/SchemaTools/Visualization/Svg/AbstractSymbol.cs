
using System.Collections.Generic;

namespace SchemaTools.Visualization.Svg
{
    public abstract class AbstractSymbol
    {
        private readonly List<AbstractSymbol> children = new List<AbstractSymbol>();


        public IEnumerable<AbstractSymbol> Children
        {
            get { return children; }
        }


        public void AddChild(AbstractSymbol child)
        {
            children.Add(child);
        }


        public override string ToString()
        {
            return "n/a";
        }
    }
}
