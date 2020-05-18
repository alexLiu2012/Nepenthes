using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphBatch : ObjectGraphType<Wa2Batch>
    {
        private Wa2Client _client;
        private TypeFieldAliasHelper _fieldAlias;
        private string _dateFormat;

        public GraphBatch(
            Wa2Client aClient,
            TypeFieldAliasHelper aFieldAlias)
        {
            this._client = aClient;
            this._fieldAlias = aFieldAlias;
            this._dateFormat = "yyyy-mm-dd";

            Name = "batch";
            Description = "batch";

            // define the self properties
            #region            

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                resolve: context => context.Source.Name);

            // display name with alias
            Field<StringGraphType>(
                name: "display_name",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // location
            Field<StringGraphType>(
                name: "location",
                description: "",
                resolve: context => context.Source.Location.TrimStart("/wa/2/locations/".ToCharArray()));

            // display name with alias
            Field<StringGraphType>(
                name: "display_location",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var location = context.Source.Location.TrimStart("/wa/2/locations/".ToCharArray());
                    var value = this._client.Retrieve<Wa2Location>().FirstOrDefault(l => l.Id == location).Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

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

            // finish time, nullable
            Field<StringGraphType>(
                name: "finish_time",
                description: "",
                resolve: context => context.Source.FinishTime.HasValue ? context.Source.FinishTime.Value.ToString(this._dateFormat) : null);            

            // animal arrival
            Field<StringGraphType>(
                name: "animal_arrival_time",
                description: "",
                resolve: context => context.Source.AnimalArrival.ToString(this._dateFormat));

            #endregion

            // define the linked properties

        }
    }
}
