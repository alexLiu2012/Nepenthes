using System;
using System.Linq;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class AlarmFieldArguments 
    {
        // define argument strings
        #region
        private const string arg_name = "names";
        private const string prop_name = "Name";

        private const string arg_location = "locations";
        private const string prop_location = "Location";

        private const string arg_category = "categories";
        private const string prop_category = "Category";

        private const string arg_group = "groups";
        private const string prop_group = "Group";

        private const string arg_code = "codes";
        private const string prop_code = "Code";

        private const string arg_source = "sources";
        private const string prop_source = "Source";

        private const string arg_type = "types";
        private const string prop_type = "Type";

        private const string arg_ceased = "ceased";
        private const string prop_ceased = "IsCeased";

        private const string arg_acknowledged = "acknowledged";
        private const string prop_acknowledged = "IsAcknowledged";

        private const string arg_acknowledgedBy = "acknowledgedBy";
        private const string prop_acknowledgedBy = "AcknowledgedBy";

        private const string arg_generationTime = "generationTime";
        private const string prop_generationTime = "GenerationTime";

        private const string arg_acknowledgedTime = "acknowledgedTime";
        private const string prop_acknowledgedTime = "AcknowledgedTime";

        private const string arg_ceasedTime = "ceasedTime";
        private const string prop_ceasedTime = "CeasedTime";
        #endregion

        private Wa2Client _client;
        private QueryArguments _arguments;        

        public AlarmFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;
            this._arguments = new QueryArguments();

            // define graph arguments
            #region
            // name, should be same with code, prefer to code
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_name,
                Description = "",
                DefaultValue = null
            });

            // location
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_location,
                Description = "",
                DefaultValue = null
            });

            // category
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_category,
            });

            // group
            this._arguments.Add(new QueryArgument<ListGraphType<IntGraphType>>()
            {
                Name = arg_group,
            });

            // code
            this._arguments.Add(new QueryArgument<ListGraphType<IntGraphType>>()
            {
                Name = arg_code,
            });

            // source
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_source,
            });

            // type
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_type,
            });

            // ceased
            this._arguments.Add(new QueryArgument<BooleanGraphType>()
            {
                Name = arg_ceased
            });

            // acknowledged
            this._arguments.Add(new QueryArgument<BooleanGraphType>()
            {
                Name = arg_acknowledged
            });

            // acknowledged by
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_acknowledgedBy
            });

            // generation time
            this._arguments.Add(new QueryArgument<ListGraphType<DateGraphType>>()
            {
                Name = arg_generationTime
            });

            // acknowledged time
            this._arguments.Add(new QueryArgument<ListGraphType<DateGraphType>>()
            {
                Name = arg_acknowledgedTime
            });

            // ceased time
            this._arguments.Add(new QueryArgument<ListGraphType<DateGraphType>>()
            {
                Name = arg_ceasedTime
            });
            #endregion

        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            var alarms = this._client.Retrieve<Wa2Alarm>();
            var locations = this._client.Retrieve<Wa2Location>();

            return context =>
            {                
                // name 
                alarms = alarms.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Alarm>(context, arg_name, prop_name));
                // location
                alarms = alarms.Where(QueryFieldArgumentHelper.LocationArgContains<Wa2Alarm>(context, arg_location, prop_location, locations));
                // category
                alarms = alarms.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Alarm>(context, arg_category, prop_category));

                // group
                alarms = alarms.Where(QueryFieldArgumentHelper.IntArgContains<Wa2Alarm>(context, arg_group, prop_group));
                // code
                alarms = alarms.Where(QueryFieldArgumentHelper.IntArgContains<Wa2Alarm>(context, arg_code, prop_code));

                // source
                alarms = alarms.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Alarm>(context, arg_source, prop_source));
                // type
                alarms = alarms.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Alarm>(context, arg_type, prop_type));

                // ceased
                alarms = alarms.Where(QueryFieldArgumentHelper.BoolArgEquals<Wa2Alarm>(context, arg_ceased, prop_ceased));
                // acknowledged
                alarms = alarms.Where(QueryFieldArgumentHelper.BoolArgEquals<Wa2Alarm>(context, arg_acknowledged, prop_acknowledged));

                // acknowledged by
                alarms = alarms.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Alarm>(context, arg_acknowledgedBy, prop_acknowledgedBy));

                // generation time
                alarms = alarms.Where(QueryFieldArgumentHelper.DateTimeArgAts<Wa2Alarm>(context, arg_generationTime, prop_generationTime));
                // acknowledged time
                alarms = alarms.Where(QueryFieldArgumentHelper.DateTimeArgAts<Wa2Alarm>(context, arg_acknowledgedTime, prop_acknowledgedTime));
                // ceased time
                alarms = alarms.Where(QueryFieldArgumentHelper.DateTimeArgAts<Wa2Alarm>(context, arg_ceasedTime, prop_ceasedTime));

                return alarms;
            };            
        }
    }
}
