using System;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class KeyValueFieldArguments 
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public KeyValueFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments()
            {
                //id --for history
                //origin
                //relatedto -> location
                //keyinfo
                //act display
                //act value
                //act unit
                //act precision
                // isreadonly
                // min
                // max
                // timestamp
                // description
                // history
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
                return this._client.Retrieve<Wa2KeyValue>();
            };            
        }
    }
}
