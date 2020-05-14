using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class ControllerFieldArguments
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public ControllerFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments()
            {
                //id
                //name
                //origin
                //applications[]
                //locations[]
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
                return _client.Retrieve<Wa2Controller>();
            };
        }
    }
}
