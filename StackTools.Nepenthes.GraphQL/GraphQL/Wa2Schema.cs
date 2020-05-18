using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class Wa2Schema : Schema
    {
        public Wa2Schema(IServiceProvider services) : base(services)
        {
            var wa2Query = services.GetRequiredService<Wa2Query>();
            var cusQuery = services.GetRequiredService<CustomQuery>();

            // add customized queries to main query
            foreach (var field in cusQuery.Fields)
            {
                wa2Query.AddField(field);
            }

            Query = wa2Query;
            Mutation = null;
            Subscription = null;              
        }
    }
}
