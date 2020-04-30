using System;

namespace StackTools.Wa2Wrapper.wa2Resource
{
    public class Wa2Alarm : Wa2ResourceItem
    {
        public string Id { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string DisplayCategory { get; set; }        
        public int Group { get; set; }
        public int Code { get; set; }
        public DateTime GenerationTime { get; set; }
        public bool IsCeased { get; set; }
        public DateTime? CeasedTime { get; set; }
        public bool CanAcknowledge { get; set; }
        public bool IsAcknowledged { get; set; }
        public string AcknowledgedBy { get; set; }
        public DateTime? AcknowledgedTime { get; set; }
        public bool AcknowledgePinCodeRequired { get; set; }
        public string Reason { get; set; }
        public string Solution { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
    }
}
