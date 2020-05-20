using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class LocationFieldArguments 
    {
        private const string arg_name = "names";
        private const string prop_name = "Name";

        private const string arg_type = "types";
        private const string prop_type = "Type";

        private Wa2Client _client;
        private QueryArguments _arguments;

        public LocationFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments();

            // name
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_name,
            });

            // type
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_type,
            });            
            
        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            var locations = this._client.Retrieve<Wa2Location>();

            return context =>
            {
                // name
                locations = locations.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Location>(context, arg_name, prop_name));

                // type 
                locations = locations.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Location>(context, arg_type, prop_type));

                return locations;
            };
        }
    }
}
