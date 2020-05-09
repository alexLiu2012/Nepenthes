using System.Collections.Generic;

namespace StackTools.Wa2Wrapper.wa2Resource
{
    public sealed class Wa2ResourceCollection<TResource>
    {
        public IEnumerable<TResource> Items { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
    }
}
