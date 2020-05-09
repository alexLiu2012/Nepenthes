using System;
using System.Collections.Generic;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class KeyValueHistoryDto
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
