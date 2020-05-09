using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using StackTools.Nepenthes.GraphQL.GraphTypes;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class Wa2Query : ObjectGraphType
    {
        private Wa2Client _client;

        public Wa2Query(Wa2Client aClient)
        {
            this._client = aClient;

            Name = "wa2query";
            Description = "wa2query";

            Field<ListGraphType<StringGraphType>>(
                name: "test",
                description: "a test field",
                arguments: new QueryArguments()
                {
                    new QueryArgument<StringGraphType>()
                    {
                        Name = "input"
                    }
                },
                resolve: context => _client.ToString() + context.GetArgument<string>("input") ?? "empty");

           
            Field<ListGraphType<GraphAlarm>>(
                name: "alarms",
                description: "",
                arguments: null,
                resolve: context => _client.Retrieve<Wa2Alarm>());


            //Field<ListGraphType<GraphApplication>>();

            Field<ListGraphType<GraphBatch>>(
                name: "batches",
                description:"",
                resolve: context => _client.Retrieve<Wa2Batch>());

            Field<ListGraphType<GraphController>>(
                name: "controllers",
                description:"",
                resolve: context => _client.Retrieve<Wa2Controller>());


            //Field<ListGraphType<GraphKeyInfo>>();
                
            Field<ListGraphType<GraphKeyValue>>(
                name: "keyvalues",
                description:"",
                arguments: null,
                resolve: context => _client.Retrieve<Wa2KeyValue>());

            Field<ListGraphType<GraphLocation>>(
                name: "locations",
                description: "",
                resolve: context => _client.Retrieve<Wa2Location>());
    
        }
    }
}
