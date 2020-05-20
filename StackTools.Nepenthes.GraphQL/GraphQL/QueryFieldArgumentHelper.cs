using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class QueryFieldArgumentHelper
    {
        public static Func<TResource, bool> StringArgContains<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<List<string>>(argName);

            bool filter(TResource t)
            {
                var propValue = t.GetType().GetProperty(propName)?.GetValue(t);

                if (argValue is null) 
                {
                    return true;
                }

                if (propValue is null) 
                {
                    return false;
                }

                return argValue.Contains((string)propValue);
            }

            return filter;
        }
        
        public static Func<TResource, bool> IntArgContains<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<List<int>>(argName);

            bool filter(TResource t)
            {
                var propValue = t.GetType().GetProperty(propName)?.GetValue(t);

                if (argValue is null)
                {
                    return true;
                }

                if (propValue is null)
                {
                    return false;
                }

                return argValue.Contains((int)propValue);
            }

            return filter;
        }

        public static Func<TResource, bool> LocationArgContains<TResource>(IResolveFieldContext<object> context, string argName, string propName, IEnumerable<Wa2Location> locations)
        {
            var argValue = context.GetArgument<List<string>>(argName);

            bool filter(TResource t)
            {
                var propValue = t.GetType().GetProperty(propName)?.GetValue(t);

                if (argValue is null)
                {
                    return true;
                }

                if (propValue is null)
                {
                    return false;
                }

                var locationId = (propValue as string).TrimStart("/wa/2/locations/".ToCharArray());
                var locationName = locationId is null ? null : locations.FirstOrDefault(loc => loc.Id == locationId)?.Name;

                return (locationId is null || locationName is null) ? false : (argValue.Contains(locationId) || argValue.Contains(locationName));
            }

            return filter;
        }        

        public static Func<TResource, bool> BoolArgEquals<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<bool?>(argName);

            bool filter(TResource t)
            {
                var propValue = t.GetType().GetProperty(propName)?.GetValue(t);

                if (argValue is null)
                {
                    return true;
                }

                if (propValue is null)
                {
                    return false;
                }

                return argValue.Value == ((bool)propValue);
            }

            return filter;
        }

        public static Func<TResource, bool> DateTimeArgAts<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<List<DateTime>>(argName);
            
            bool filter(TResource t)
            {
                var propValue = t.GetType().GetProperty(propName)?.GetValue(t);

                if (argValue is null)
                {
                    return true;
                }

                if (propValue is null)
                {
                    return false;
                }

                var dateStrs = argValue.Select(date => date.ToShortDateString());

                return dateStrs.Contains(((DateTime)propValue).ToShortDateString());
            }

            return filter;
        }

    }
}
