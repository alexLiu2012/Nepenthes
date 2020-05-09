using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphKeyInfo : ObjectGraphType<Wa2KeyInfo>
    {
        public GraphKeyInfo()
        {
            Name = "";
            Description = "";

            // id
            Field<StringGraphType>(
                name: "id",
                description: "",
                resolve: context => context.Source.Id);
            // category

            // group

            // name

            // disp category

            // disp group

            // disp name

            // disp description

            // value type

            // keyvalue type

            // readonly

            // advanced
        }
    }
}
