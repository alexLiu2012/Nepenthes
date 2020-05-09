using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphBatch : ObjectGraphType<Wa2Batch>
    {
        private string _dateFormat;

        public GraphBatch()
        {
            this._dateFormat = "yyyy-mm-dd";

            Name = "batch";
            Description = "batch";

            // id
            Field<StringGraphType>(
                name: "id",
                description: "",
                resolve: context => context.Source.Id);

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                resolve: context => context.Source.Name);

            // location
            Field<StringGraphType>(
                name: "location",
                description: "",
                resolve: context => context.Source.Location);   // trim start 

            // generation time
            Field<StringGraphType>(
                name: "generation_time",
                description: "",
                resolve: context => context.Source.GenerationTime.ToString(this._dateFormat));

            // start time
            Field<StringGraphType>(
                name: "start_time",
                description: "",
                resolve: context => context.Source.StartTime.ToString(this._dateFormat));

            // ? finish time
            Field<StringGraphType>(
                name: "finish_time",
                description: "",
                resolve: context => context.Source.FinishTime.HasValue ? context.Source.FinishTime.Value.ToString(this._dateFormat) : null);

            // state
            Field<StringGraphType>(
                name: "state",
                description: "",
                resolve: context => context.Source.State);

            // day no
            Field<StringGraphType>(
                name: "day_no",
                description: "",
                resolve: context => context.Source.DayNo);

            // animal arrival
            Field<StringGraphType>(
                name: "animal_arrival_time",
                description: "",
                resolve: context => context.Source.AnimalArrival.ToString(this._dateFormat));
        }
    }
}
