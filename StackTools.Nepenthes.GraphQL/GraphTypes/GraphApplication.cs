using System.Linq;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphApplication : ObjectGraphType<Wa2Application>
    {
        private Wa2Client _client;
        private TypeFieldAliasHelper _fieldAlias;

        public GraphApplication(
            Wa2Client aClient,
            TypeFieldAliasHelper afieldAlias)
        {
            this._client = aClient;
            this._fieldAlias = afieldAlias;
            
            Name = "applications";
            Description = "applications";

            // define the self properties
            #region            

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                arguments: null,    // can use alias
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

            // location
            Field<StringGraphType>(
                name: "location",
                description: "",                
                resolve: context => context.Source.Locations.FirstOrDefault());

            // display location with alias
            Field<StringGraphType>(
                name: "display_location",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var location = context.Source.Locations.FirstOrDefault();
                    var value = this._client.Retrieve<Wa2Location>().FirstOrDefault(l => l.Id == location).Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // type
            Field<StringGraphType>(
                name: "type",
                description: "",                
                resolve: context => context.Source.Type);

            // display type
            Field<StringGraphType>(
                name: "display_type",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.Type;
                    return this._fieldAlias.GetAlias(context, value);
                });
            
            #endregion

            // define the linked properties

        }
    }
}
