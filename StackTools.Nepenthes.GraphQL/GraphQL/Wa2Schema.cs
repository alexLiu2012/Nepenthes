using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class Wa2Schema : Schema
    {
        public Wa2Schema(IServiceProvider services) : base(services)
        {
            var mainQuery = services.GetRequiredService<Wa2Query>();
            var cusQuery = services.GetRequiredService<CustomQuery>();

            // add customized queries to main query
            foreach (var field in cusQuery.Fields)
            {
                mainQuery.AddField(field);
            }

            Query = mainQuery;
            Mutation = null;
            Subscription = null;              
        }
    }
}
