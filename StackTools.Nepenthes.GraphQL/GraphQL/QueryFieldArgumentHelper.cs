using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class QueryFieldArgumentHelper
    {
        public static Func<TResource, bool> StringArgContains<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<List<string>>(argName);

            bool filter(TResource t)
            {
                var propValue = (string?)t.GetType().GetProperty(propName).GetValue(t);
                return (argValue is null) ? true : (propValue is null) ? false : argValue.Contains(propValue);
            }

            return filter;
        }
        
        public static Func<TResource, bool> BoolArgEquals<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<bool?>(argName);

            bool filter(TResource t)
            {
                var propValue = (bool?)t.GetType().GetProperty(propName).GetValue(t);
                return (argValue is null) ? true : (propValue is null) ? false : argValue.Value == propValue.Value;
            }

            return filter;
        }

        public static Func<TResource, bool> DateTimeArgBetweens<TResource>(IResolveFieldContext<object> context, string argName, string propName)
        {
            var argValue = context.GetArgument<DateTime?>(argName);

            bool filter(TResource t)
            {
                var propValue = (DateTime?)t.GetType().GetProperty(propName).GetValue(t);
                return (argValue is null) ? true : (propValue is null) ? false : false;
            }

            return filter;
        }


    }
}
