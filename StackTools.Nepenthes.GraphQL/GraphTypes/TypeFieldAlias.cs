using System.Collections.Generic;
using System.Linq;

namespace StackTools.Nepenthes.GraphQL.GraphTypes
{
    public class TypeFieldAlias
    {
        public List<string> AlarmAlias { get; set; }
        public List<string> ApplicationAlias { get; set; }
        public List<string> BatchAlias { get; set; }
        public List<string> ControllerAlias { get; set; }
        public List<string> KeyInfoAlias { get; set; }
        public List<string> KeyValueAlias { get; set; }
        public List<string> LocationAlias { get; set; }

        public TypeFieldAlias()
        {
            this.AlarmAlias = new List<string>();
            this.ApplicationAlias = new List<string>();
            this.BatchAlias = new List<string>();
            this.ControllerAlias = new List<string>();
            this.KeyInfoAlias = new List<string>();
            this.KeyValueAlias = new List<string>();
            this.LocationAlias = new List<string>();
        }

        public List<string> GetAliasStrings()
        {
            var strs = new List<string>();

            strs.AddRange(this.AlarmAlias);
            strs.AddRange(this.ApplicationAlias);
            strs.AddRange(this.BatchAlias);
            strs.AddRange(this.ControllerAlias);
            strs.AddRange(this.KeyInfoAlias);
            strs.AddRange(this.KeyValueAlias);
            strs.AddRange(this.LocationAlias);

            return strs.Distinct().ToList();
        }
    }
}
