using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class TypeFieldAliasHelper
    {        
        private const string byAlias = "alias";        
        private TypeFieldAlias _fieldAlias;

        public QueryArguments Arguments { get; }

        public TypeFieldAliasHelper(TypeFieldAlias aFieldAlias)
        {                  
            this._fieldAlias = aFieldAlias;

            this.Arguments = new QueryArguments()
            {                
                new QueryArgument<ListGraphType<StringGraphType>>
                {
                    Name = byAlias,
                    Description = "",
                    DefaultValue = null
                }
            };
        }

        public string GetAlias(IResolveFieldContext<object> context, string value)
        {
            var aliasInput = context.GetArgument<List<string>>(byAlias);
            if (aliasInput is null)
            {
                return value;
            }
            else
            {                              
                var aliases = (aliasInput.Count == 1 && aliasInput[0] == string.Empty) 
                    ? this.GetAliasDictionary(this._fieldAlias.GetAliasStrings())
                    : this.GetAliasDictionary(aliasInput);

                // may throw null exception?
                return aliases.GetValueOrDefault(value, value);
            }            
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
                    dictionary.TryAdd(kvPair[0].Trim(), kvPair[1].Trim());
                }
            }
            
            return dictionary;
        }
        
    }
}
