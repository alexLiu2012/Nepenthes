using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{    
    public class ControllerFieldArguments
    {
        private const string arg_name = "names";
        private const string prop_name = "Name";

        private Wa2Client _client;
        private QueryArguments _arguments;

        public ControllerFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments();

            // name
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_name
            });

            // location
            
        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            var controllers = this._client.Retrieve<Wa2Controller>();
            var locations = this._client.Retrieve<Wa2Location>();

            return context =>
            {
                // name
                controllers = controllers.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Controller>(context, arg_name, prop_name));

                return controllers;
            };
        }
    }
}
