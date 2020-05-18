using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphLocation : ObjectGraphType<Wa2Location>
    {
        private Wa2Client _client;
        private TypeFieldAliasHelper _fieldAlias;

        public GraphLocation(
            Wa2Client aClient,
            TypeFieldAliasHelper aFieldAlias)
        {
            this._client = aClient;
            this._fieldAlias = aFieldAlias;

            Name = "locations";
            Description = "";

            // define the self properties
            #region            

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                resolve: context => context.Source.Name);

            // display name with alias
            Field<StringGraphType>(
                name: "display_name",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // type
            Field<StringGraphType>(
                name: "type",
                description: "",                
                resolve: context => context.Source.Type);

            // display type with alias
            Field<StringGraphType>(
                name: "display_type",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.Type;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // parent
            Field<StringGraphType>(
                name: "parent",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Parent);

            // children, nullable
            Field<ListGraphType<StringGraphType>>(
                name: "children",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Children);
            
            #endregion

            // define the linked properties

        }
    }
}
