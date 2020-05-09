using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphAlarm : ObjectGraphType<Wa2Alarm>
    {
        private string _dateFormat;

        public GraphAlarm()
        {
            this._dateFormat = "yyyy-mm-dd";

            Name = "alarm";
            Description = "alarm";

            // id
            Field<StringGraphType>(
                name: "id",                
                description: "",                
                resolve: context => context.Source.Id);

            // origin
            Field<StringGraphType>(
                name: "origin",
                description: "",
                resolve: context => context.Source.Origin);

            // name
            Field<StringGraphType>(
                name: "name",
                description: "",
                resolve: context => context.Source.Name);

            // displayName
            Field<StringGraphType>(
                name: "display_name",
                description: "",
                resolve: context => context.Source.DisplayName);

            // description
            Field<StringGraphType>(
                name: "description",
                description: "",
                resolve: context => context.Source.Description);

            // location
            Field<StringGraphType>(
                name: "location",
                description: "",
                resolve: context => context.Source.Location.TrimStart("/wa/2/locations/".ToCharArray()));   

            // category
            Field<StringGraphType>(
                name: "category",
                description: "",
                resolve: context => context.Source.Category);

            // dispalyCategory
            Field<StringGraphType>(
                name: "display_category",
                description: "",
                resolve: context => context.Source.DisplayCategory);

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

            // generation time
            Field<StringGraphType>(
                name: "generation_time",
                description: "",
                resolve: context => context.Source.GenerationTime.ToString(this._dateFormat));  

            // isCeased
            Field<BooleanGraphType>(
                name: "is_ceased",
                description: "",
                resolve: context => context.Source.IsCeased);

            // ? ceased time
            Field<StringGraphType>(
                name: "ceased_time",
                description: "",
                resolve: context =>
                    context.Source.CeasedTime.HasValue ? context.Source.CeasedTime.Value.ToString(this._dateFormat) : null);  

            // can acknowledge
            Field<BooleanGraphType>(
                name: "can_acknowledge",
                description: "",
                resolve: context => context.Source.CanAcknowledge);

            // ? acknowledged by 
            Field<StringGraphType>(
                name: "acknowledged_by",
                description: "",
                resolve: context => context.Source.AcknowledgedBy);

            // ? acknowledged time
            Field<StringGraphType>(
                name: "acknowledge_time",
                description: "",
                resolve: context =>
                    context.Source.AcknowledgedTime.HasValue ? context.Source.AcknowledgedTime.Value.ToString(this._dateFormat) : null);            

            // string reason

            // solution

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

        }
    }
}
