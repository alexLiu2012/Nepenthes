using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class CustomQuery : ObjectGraphType
    {
        public CustomQuery()
        {
            Name = "custom";
            Description = "custom_query";

            /*
            Field<StringGraphType>(
                name: "cus",
                description: "cus",
                arguments: null,
                resolve: context => "hello");

            */
        }
    }
}
