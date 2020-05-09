using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphController : ObjectGraphType<Wa2Controller>
    {
        public GraphController()
        {
            Name = "controllers";
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

            // origin
            Field<StringGraphType>(
                name: "origin",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Origin);

            // applications
            // should use linked resource??
            Field<ListGraphType<StringGraphType>>(
                name: "applications",
                description: "",
                resolve: context => context.Source.Applications);

            // locations
            // should use linked resource??
            Field<StringGraphType>(
                name: "locations",
                description: "",
                resolve: context => context.Source.Locations);
        }
    }
}
