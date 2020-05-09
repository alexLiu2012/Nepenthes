namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class KeyInfoDto
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }

        // properties in nested Display class
        public string DispCategory { get; set; }
        public string DispGroup { get; set; }
        public string DispName { get; set; }
        public string DispDescription { get; set; }
        
        public string ValueType { get; set; }
        public string KeyValueType { get; set; }
        public bool ReadOnly { get; set; }
        public bool Advanced { get; set; }
    }
}
