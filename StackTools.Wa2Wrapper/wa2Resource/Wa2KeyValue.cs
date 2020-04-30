using System;

namespace StackTools.Wa2Wrapper.wa2Resource
{
    public class Wa2KeyValue : Wa2ResourceItem
    {
        public string Id { get; set; }
        public string Origin { get; set; }
        public string RelatedTo { get; set; }
        public string KeyInfo { get; set; }
        public class ActualDef
        {
            public string Display { get; set; }
            public string Value { get; set; }
            public string Unit { get; set; }
            public int Precision { get; set; }
            public bool IsReadonly { get; set; }
        }
        public ActualDef Actual { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
    }
}
