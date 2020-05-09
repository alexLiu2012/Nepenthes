using System.Linq;
using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphApplication : ObjectGraphType<Wa2Application>
    {
        public GraphApplication()
        {
            Name = "";
            Description = "";

            // id
            Field<StringGraphType>(
                name: "id",
                description: "",
                resolve: context => context.Source.Id);

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                arguments: null,    // can use alias
                resolve: context => context.Source.Name);

            // type
            Field<StringGraphType>(
                name: "type",
                description: "",
                arguments: null,    // can use alias
                resolve: context => context.Source.Type);

            // origin
            Field<StringGraphType>(
                name: "origin",
                description: "",
                resolve: context => context.Source.Origin);     // use alias??

            // location
            Field<StringGraphType>(
                name: "location",
                description: "",
                arguments: null,    // can use alias
                                    // a compromised way to show location name, prefer than add extension field directly
                resolve: context => context.Source.Locations.FirstOrDefault());

        }
    }
}
