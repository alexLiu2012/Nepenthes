namespace StackTools.Wa2Wrapper.wa2Resource
{
    public class Wa2KeyInfo : Wa2ResourceItem
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public class DisplayDef
        {
            public string Category { get; set; }
            public string Group { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        public DisplayDef Display { get; set; }
        public string ValueType { get; set; }
        public string KeyValueType { get; set; }
        public bool ReadOnly { get; set; }
        public bool Advanced { get; set; }
    }
}
