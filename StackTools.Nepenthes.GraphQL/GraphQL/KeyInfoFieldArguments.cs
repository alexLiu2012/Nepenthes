using System;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class KeyInfoFieldArguments 
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public KeyInfoFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments()
            {
                //id
                //category
                //group
                //name
                //disp category
                //disp group
                //disp name
                //disp description
                //value type
                //keyvalue type
                //readonly
                // advanced

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
                return _client.Retrieve<Wa2KeyInfo>();
            };
        }
    }
}
