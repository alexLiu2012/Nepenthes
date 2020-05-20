using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;
using System.Globalization;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphAlarm : ObjectGraphType<Wa2Alarm>
    {
        private Wa2Client _client;
        private TypeFieldAliasHelper _fieldAlias;
        private string _dateFormatString;
        
        public GraphAlarm(
            Wa2Client aClient,
            TypeFieldAliasHelper afieldAlias,
            DateTimeFormatInfo aDateTimeFormat)
        {
            this._client = aClient;
            this._fieldAlias = afieldAlias;
            this._dateFormatString = aDateTimeFormat.FullDateTimePattern;                        
            
            Name = "alarm";
            Description = "alarm";            
            
            // define the slef properties
            #region  
            
            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                resolve: context => context.Source.Name);

            // displayName with alias
            Field<StringGraphType>(
                name: "display_name",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.DisplayName;
                    return this._fieldAlias.GetAlias(context, value);
                });
                
            // location
            Field<StringGraphType>(
                name: "location",
                description: "",
                resolve: context => context.Source.Location.TrimStart("/wa/2/locations/".ToCharArray()));

            // displayLocation with alias
            Field<StringGraphType>(
                name: "display_location",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var location = context.Source.Location.TrimStart("/wa/2/locations/".ToCharArray());
                    var value = this._client.Retrieve<Wa2Location>().FirstOrDefault(l => l.Id == location).Name;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // category
            Field<StringGraphType>(
                name: "category",
                description: "",
                resolve: context => context.Source.Category);

            // dispalyCategory with alias
            Field<StringGraphType>(
                name: "display_category",
                description: "",
                arguments: this._fieldAlias.Arguments,
                resolve: context =>
                {
                    var value = context.Source.DisplayCategory;
                    return this._fieldAlias.GetAlias(context, value);
                });

            // group
            Field<IntGraphType>(
                name: "group",
                description: "",
                resolve: context => context.Source.Group);

            // code
            Field<IntGraphType>(
                name: "code",
                description: "",
                resolve: context => context.Source.Code);

            // source
            Field<StringGraphType>(
                name: "source",
                description: "",
                resolve: context => context.Source.Source);

            // type 
            Field<StringGraphType>(
                name: "type",
                description: "",
                resolve: context => context.Source.Type);

            // isCeased
            Field<BooleanGraphType>(
                name: "is_ceased",
                description: "",
                resolve: context => context.Source.IsCeased);

            // is acknowledged
            Field<BooleanGraphType>(
                name: "is_acknowledged",
                description: "",
                resolve: context => context.Source.IsAcknowledged);

            // acknowledged by, nullable
            Field<StringGraphType>(
                name: "acknowledged_by",
                description: "",
                resolve: context => context.Source.AcknowledgedBy);

            // generation time
            Field<StringGraphType>(
                name: "generation_time",
                description: "",
                resolve: context => context.Source.GenerationTime.ToString(this._dateFormatString));

            // acknowledged time, nullable
            Field<StringGraphType>(
                name: "acknowledge_time",
                description: "",
                resolve: context =>
                    context.Source.AcknowledgedTime.HasValue ? context.Source.AcknowledgedTime.Value.ToString(this._dateFormatString) : null);

            // ceased time, nullable
            Field<StringGraphType>(
                name: "ceased_time",
                description: "",
                resolve: context =>
                    context.Source.CeasedTime.HasValue ? context.Source.CeasedTime.Value.ToString(this._dateFormatString) : null);

            // description
            Field<StringGraphType>(
                name: "description",
                description: "",
                resolve: context => context.Source.Description);                                                                                                                     

            #endregion

            // define the related properties

        }
    }
}
