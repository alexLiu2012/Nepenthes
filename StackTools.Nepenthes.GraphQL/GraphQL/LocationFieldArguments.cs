using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class LocationFieldArguments 
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public LocationFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments()
            {
                //id

                //name

                //type

                //origin

                //parent

                //children[]
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
                return _client.Retrieve<Wa2Location>();
            };
        }
    }
}
