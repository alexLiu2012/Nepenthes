using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class GraphKeyValue : ObjectGraphType<Wa2KeyValue>
    {
        private string _dateFormat;

        public GraphKeyValue()
        {
            this._dateFormat = "yyyy-mm-dd";

            Name = "keyvalues";
            Description = "";

            // id
            Field<StringGraphType>(
                name: "id",
                description: "",
                resolve: context => context.Source.Id);

            // origin
            Field<StringGraphType>(
                name: "origin",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.Origin);

            // related to
            Field<StringGraphType>(
                name: "location",
                description: "",
                arguments: null,    // use alias as location name
                resolve: context => context.Source.RelatedTo.TrimStart("/wa/2/locations/".ToCharArray()));

            // keyinfo
            Field<StringGraphType>(
                name: "keyinfo",
                description: "",
                arguments: null,    // use alias
                resolve: context => context.Source.KeyInfo);

            // display
            Field<StringGraphType>(
                name: "display",
                description: "",
                resolve: context => context.Source.Actual.Display);

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

            // precision
            Field<IntGraphType>(
                name: "precision",
                description: "",
                resolve: context => context.Source.Actual.Precision);

            // is readonly
            Field<BooleanGraphType>(
                name: "is_readonly",
                description: "",
                resolve: context => context.Source.Actual.IsReadonly);

            // min
            Field<FloatGraphType>(
                name: "min",
                description: "",
                resolve: context => context.Source.Min);

            // max
            Field<StringGraphType>(
                name: "max",
                description: "",
                resolve: context => context.Source.Max);

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

        }

    }
}
