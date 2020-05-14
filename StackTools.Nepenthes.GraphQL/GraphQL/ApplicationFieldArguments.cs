using System;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class ApplicationFieldArguments 
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public ApplicationFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments()
            {
                //id
                //name
                //type
                //origin
                //locations

            };
        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            return context =>
            {
                return _client.Retrieve<Wa2Application>();
            };
        }

    }
}
