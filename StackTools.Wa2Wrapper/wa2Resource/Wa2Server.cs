using System.Collections.Generic;

namespace StackTools.Wa2Wrapper.wa2Resource
{
    public class Wa2Server : Wa2ResourceItem
    {
        public string Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public List<string> Apis { get; set; }
    }
}
