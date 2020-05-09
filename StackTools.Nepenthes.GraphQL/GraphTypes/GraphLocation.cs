using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphLocation : ObjectGraphType<Wa2Location>
    {
        public GraphLocation()
        {
            Name = "locations";
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
                resolve: context => context.Source.Name);

            // type
            Field<StringGraphType>(
                name: "type",
                description: "",
                arguments: null,    // use alias expecial an enum 
                resolve: context => context.Source.Type);

            // origin
            Field<StringGraphType>(
                name: "origin",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Origin);

            // parent
            Field<StringGraphType>(
                name: "parent",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Parent);

            // ? children
            Field<StringGraphType>(
                name: "children",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Children);
        }
    }
}
