using System.Collections.Generic;

namespace StackTools.Wa2Wrapper.wa2Resource
{
    public class Wa2Controller : Wa2ResourceItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public List<string> Applications { get; set; }
        public List<string> Locations { get; set; }
    }
}
