using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class ApplicationFieldArguments 
    {
        private const string arg_name = "names";
        private const string prop_name = "Name";

        private const string arg_location = "locations";        
        
        private const string arg_type = "types";
        private const string prop_type = "Type";
        
        private Wa2Client _client;   
        private QueryArguments _arguments;                     

        public ApplicationFieldArguments(Wa2Client aClient)
        {
            this._client = aClient;            
            this._arguments = new QueryArguments();

            // argument name
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_name,
                Description = "",
                DefaultValue = null
            });

            // argument location
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_location,
                Description = "",
                DefaultValue = null
            });

            // argument type
            this._arguments.Add(new QueryArgument<ListGraphType<StringGraphType>>()
            {
                Name = arg_type,
                Description = "",
                DefaultValue = null
            });            
            
        }

        public QueryArguments GetArguments()
        {
            return this._arguments;
        }

        public Func<IResolveFieldContext<object>, object> GetResolver()
        {
            var applications = this._client.Retrieve<Wa2Application>();
            var locations = this._client.Retrieve<Wa2Location>();

            return context =>
            {
                // name
                applications = applications.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Application>(context, arg_name, prop_name));

                // location
                applications = applications.Where(p =>
                {
                    var argValue = context.GetArgument<List<string>>(arg_location);
                    
                    if (argValue is null) 
                    {
                        return true;
                    }
                    
                    var locIds = p.Locations;
                    var locNames = locations?.Where(loc => locIds.Contains(loc.Id))?.Select(location => location.Name);

                    if (locIds is null || locNames is null)
                    {
                        return false;
                    }

                    var flag_id = false;
                    var flag_name = false;

                    foreach (var locId in locIds)
                    {
                        flag_id = argValue.Contains(locId);
                    }

                    foreach (var locName in locNames)
                    {
                        flag_name = argValue.Contains(locName);
                    }

                    return flag_id || flag_name;
                });                

                // type
                applications = applications.Where(QueryFieldArgumentHelper.StringArgContains<Wa2Application>(context, arg_type, prop_type));

                return applications;
            };
        }

    }
}
