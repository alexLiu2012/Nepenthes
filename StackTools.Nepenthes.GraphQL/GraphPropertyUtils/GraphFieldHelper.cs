using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace StackTools.Nepenthes.GraphQL.GraphPropertyUtils
{
    public class GraphFieldHelper<T>
    {



        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }


        public Func<IResolveFieldContext<T>, object> GetResolve()
        {
            return context => "hello";
        }
    }
}
