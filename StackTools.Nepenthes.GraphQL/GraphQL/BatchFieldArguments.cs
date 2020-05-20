using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class BatchFieldArguments
    {
        private const string arg_name = "names";
        private const string prop_name = "Name";

        private const string arg_location = "locations";
        private const string prop_location = "Location";

        private const string arg_state = "states";
        private const string prop_state = "State";

        private const string arg_day_no = "day_nos";
        private const string prop_day_no = "DayNo";

        private Wa2Client _client;
        private QueryArguments _arguments;

        public BatchFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments();

            // name
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_name,
                Description = "",
                DefaultValue = null
            });

            // location
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_location,
            });
            // state
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_state
            });
            // day no
            this._arguments.Add(new QueryArgument<ListGraphType<IntGraphType>>()
            {
                Name = arg_day_no
            });

        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            var batches = this._client.Retrieve<Wa2Batch>();
            var locations = this._client.Retrieve<Wa2Location>();

            return context =>
            {
                // name
                batches = batches.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Batch>(context, arg_name, prop_name));

                // location
                batches = batches.Where(QueryFieldArgumentHelper.LocationArgContains<Wa2Batch>(context, arg_location, prop_location, locations));

                // state
                batches = batches.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Batch>(context, arg_state, prop_state));

                // day no
                batches = batches.Where(QueryFieldArgumentHelper.IntArgContains<Wa2Batch>(context, arg_day_no, prop_day_no));

                return batches;
            };
        }
    }
}
