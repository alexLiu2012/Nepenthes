using System.Collections.Generic;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class ServerDto
    {
        public string Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public List<string> Apis { get; set; }
    }
}
