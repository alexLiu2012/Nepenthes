using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphController : ObjectGraphType<Wa2Controller>
    {
        private Wa2Client _client;
        private TypeFieldAliasHelper _fieldAlias;

        public GraphController(
            Wa2Client aClient,
            TypeFieldAliasHelper aFieldAlias)
        {
            this._client = aClient;
            this._fieldAlias = aFieldAlias;

            Name = "controllers";
            Description = "";

            // define the self properties
            #region            

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                resolve: context => context.Source.Name);

            // display name
            Field<StringGraphType>(
                name: "display_name",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // applications
            // should use linked resource??
            Field<ListGraphType<StringGraphType>>(
                name: "applications",
                description: "",
                resolve: context => context.Source.Applications);

            // locations
            // should use linked resource??
            Field<ListGraphType<StringGraphType>>(
                name: "locations",
                description: "",
                resolve: context => context.Source.Locations);

            // display application??


            // services access?



            #endregion


            // define the linked properties

        }
    }
}
