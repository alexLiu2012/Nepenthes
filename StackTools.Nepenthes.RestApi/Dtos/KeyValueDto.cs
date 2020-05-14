using System;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class KeyValueDto
    {
        //public string Id { get; set; }
        //public string Origin { get; set; }

        public string RelatedTo { get; set; }
        public string KeyInfo { get; set; }

        // properties in nested Actual class
        public string Display { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
        public int Precision { get; set; }
        public bool IsReadonly { get; set; }
        
        public string Min { get; set; }
        public string Max { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

        //public string History { get; set; }
    }
}
