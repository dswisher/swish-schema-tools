
namespace SchemaTools.Visualization.Svg
{
    public class ElementSymbol : AbstractSymbol
    {
        public string Name { get; set; }
        public string Type { get; set; }


        public override string ToString()
        {
            return $"Element: {Name} type {Type}";
        }
    }
}
