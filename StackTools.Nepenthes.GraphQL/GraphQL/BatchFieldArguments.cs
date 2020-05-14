using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class BatchFieldArguments
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public BatchFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments()
            {
                // id
                // name
                // location
                // generation time
                // start time
                // finish time
                // state
                // dayno
                // animal arrival

            };
        }

        public QueryArguments GetArguments()
        {
            throw new NotImplementedException();
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            return context =>
            {
                return _client.Retrieve<Wa2Batch>();
            };
        }
    }
}
