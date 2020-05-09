using System;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class BatchDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime GenerationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string State { get; set; }
        public int DayNo { get; set; }
        public DateTime AnimalArrival { get; set; }
    }
}
