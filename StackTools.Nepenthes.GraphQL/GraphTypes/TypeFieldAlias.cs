using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;


namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class TypeFieldAlias<TWa2Resource>
    {
        private const string aliasActive = "inAlias";
        private const string aliasInput = "aliases";

        private Dictionary<string, string> _aliasesLoaded;

        public QueryArguments Arguments { get; }

        public TypeFieldAlias()
        {
            // inject custom alias container (dictionary)
            this._aliasesLoaded = new Dictionary<string, string>();

            this.Arguments = new QueryArguments()
            {
                new QueryArgument<BooleanGraphType>
                {
                    Name = "useAlias",
                    Description = "",
                    DefaultValue = false
                },

                new QueryArgument<ListGraphType<StringGraphType>>
                {
                    Name = "aliasInput",
                    Description = "",
                    DefaultValue = new List<string>()
                }
            };
        }
                 

        public Func<IResolveFieldContext<TWa2Resource>, object> GetResolver(string proName, string trimWith = null)
        {            
            return context =>
            {
                var useAlias = context.GetArgument<bool>(aliasActive);
                var oriValue = context.Source.GetType().GetProperty(proName).GetValue(context.Source);

                if (!useAlias)
                {
                    return oriValue;
                }
                else
                {
                    var value = oriValue as string;

                    var input = context.GetArgument<List<string>>(aliasInput);
                    var aliases = input is null ? this._aliasesLoaded : this.GetAliasDictionary(input);

                    return aliases.GetValueOrDefault(value, value);
                }
            };
        }

        // get aliases dictionary from input 
        private Dictionary<string, string> GetAliasDictionary(List<string> aliases)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (var alias in aliases)
            {
                var kvPair = alias.Split('=');

                if (2 == kvPair.Length)
                {
                    dictionary.TryAdd(kvPair[0], kvPair[1]);
                }
            }
            
            return dictionary;
        }
        
    }
}
