using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class AlarmFieldArguments 
    {
        private Wa2Client _client;
        private QueryArguments _arguments;

        public AlarmFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;

            this._arguments = new QueryArguments()
            {                                           
                // ids
                // origins

                // names
                new QueryArgument<ListGraphType<StringGraphType>>()
                {
                    Name = "name",
                    Description = "",
                    DefaultValue = null                     
                },

                // displaynames
                // description
                // locations
                
                // category
                new QueryArgument<ListGraphType<StringGraphType>>()
                {
                    Name = "category",
                    Description = "",
                    DefaultValue = null
                },

                // displaycategory
                
                // group
                new QueryArgument<ListGraphType<IntGraphType>>()
                {
                    Name = "group",
                    Description = "",
                    DefaultValue = null
                },

                // code
                new QueryArgument<ListGraphType<IntGraphType>>()
                {
                    Name = "code",
                    Description = "",
                    DefaultValue = null
                },

                // generation time
                
                // isceased 
                
                // ceased time

                // can acknowledge
                // is acknowledged
                new QueryArgument<BooleanGraphType>()
                {
                    Name = "isAcked",
                    Description = "",
                    DefaultValue = false
                },

                // acknowledged by
                new QueryArgument<ListGraphType<StringGraphType>>()
                {
                    Name = "ackedBy",
                    Description = "",
                    DefaultValue = null
                },

                // acknowledged time

                // acknowledge pin code required

                // source
                new QueryArgument<ListGraphType<StringGraphType>>()
                {
                    Name = "source",
                    Description = "",
                    DefaultValue = null
                },

                // type
                new QueryArgument<ListGraphType<StringGraphType>>()
                {
                    Name = "type",
                    Description = "",
                    DefaultValue = null
                }
               
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
                var alarms = this._client.Retrieve<Wa2Alarm>();

                // ids
                // origins
                // names
                
                // displaynames
                // description
                // locations

                // category

                // displaycategory

                // group

                // code

                // generation time

                // isceased 

                // ceased time

                // can acknowledge
                // is acknowledged

                // acknowledged by

                // acknowledged time

                // acknowledge pin code required

                // source
                // type

                return alarms;
            };            
        }
    }
}
