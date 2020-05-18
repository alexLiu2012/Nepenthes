using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphKeyValue : ObjectGraphType<Wa2KeyValue>
    {
        private Wa2Client _client;
        private TypeFieldAliasHelper _fieldAlias;
        private string _dateFormat;

        public GraphKeyValue(
            Wa2Client aClient,
            TypeFieldAliasHelper aFieldAlias)
        {
            this._client = aClient;
            this._fieldAlias = aFieldAlias;
            this._dateFormat = "yyyy-mm-dd";

            Name = "keyvalues";
            Description = "";

            // define the self properties
            #region                        

            // keyinfo -> name
            Field<StringGraphType>(
                name: "name",
                description: "",                
                resolve: context => context.Source.KeyInfo);

            // display name
            Field<StringGraphType>(
                name: "display_name",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.KeyInfo;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // related to -> location
            Field<StringGraphType>(
                name: "location",
                description: "",                
                resolve: context => context.Source.RelatedTo.TrimStart("/wa/2/locations/".ToCharArray()));

            // display location with alias
            Field<StringGraphType>(
                name: "display_location",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var location = context.Source.RelatedTo.TrimStart("/wa/2/locations/".ToCharArray());
                    var value = this._client.Retrieve<Wa2Location>().FirstOrDefault(l => l.Id == location).Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // value
            Field<StringGraphType>(
                name: "value",
                description: "",
                resolve: context => context.Source.Actual.Value);

            // unit
            Field<StringGraphType>(
                name: "unit",
                description: "",
                resolve: context => context.Source.Actual.Unit);

            // display
            Field<StringGraphType>(
                name: "display",
                description: "",
                resolve: context => context.Source.Actual.Display);                                                

            // timestamp
            Field<StringGraphType>(
                name: "timestamp",
                description: "",
                resolve: context => context.Source.Timestamp.ToString(this._dateFormat));

            // description
            Field<StringGraphType>(
                name: "description",
                description: "",
                resolve: context => context.Source.Description);

            // history
            Field<StringGraphType>(
                name: "history",
                description: "",
                resolve: context => context.Source.History);

            #endregion

            // define the linked properties
        }

    }
}
