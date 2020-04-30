using System;
using System.Collections.Generic;

namespace StackTools.Wa2Wrapper.wa2Resource
{
    public class Wa2KeyValueHistory
    {
        public string Id { get; set; }
        public string Origin { get; set; }
        public string RelatedTo { get; set; }
        public string KeyInfo { get; set; }
        public List<string> Values { get; set; }
        public List<DateTime> Timestamps { get; set; }
        public string Unit { get; set; }
        public int Precision { get; set; }
    }
}
