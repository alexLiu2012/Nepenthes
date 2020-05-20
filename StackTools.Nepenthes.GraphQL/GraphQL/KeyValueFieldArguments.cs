using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class KeyValueFieldArguments 
    {
        private const string arg_name = "names";        

        private const string arg_location = "locations";
        private const string prop_location = "RelatedTo";

        private const string arg_category = "categories";        

        private Wa2Client _client;
        private QueryArguments _arguments;

        public KeyValueFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments();

            // name
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_name,
            });

            // location
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_location
            });

            // category
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_category
            });

        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            var keyvalues = this._client.Retrieve<Wa2KeyValue>();
            var locations = this._client.Retrieve<Wa2Location>();

            return context =>
            {
                // name
                keyvalues = keyvalues.Where(keyvalue =>
                {
                    var argValue = context.GetArgument<List<string>>(arg_name);
                    var propValue = keyvalue.KeyInfo.Split('/')?.LastOrDefault();

                    if(argValue is null)
                    {
                        return true;
                    }

                    if(propValue is null)
                    {
                        return false;
                    }

                    return argValue.Contains(propValue);
                });

                // location
                keyvalues = keyvalues.Where(QueryFieldArgumentHelper.LocationArgContains<Wa2KeyValue>(context, arg_location, prop_location, locations));

                // category
                keyvalues = keyvalues.Where(keyvalue =>
                {
                    var argValue = context.GetArgument<List<string>>(arg_category);
                    var propValue = keyvalue.KeyInfo.Split('/').FirstOrDefault();

                    if (argValue is null)
                    {
                        return true;
                    }

                    if (propValue is null)
                    {
                        return false;
                    }

                    return argValue.Contains(propValue);
                });

                return keyvalues;
            };            
        }
    }
}
