﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SAHB.GraphQL.Client.Introspection.Validation;
using SAHB.GraphQLClient.FieldBuilder;
using SAHB.GraphQLClient.Introspection;

namespace SAHB.GraphQLClient
{
    public interface IGraphQLRequest<out TInput>
        : IGraphQLRequestInformation
        where TInput : class
    {
        IReadOnlyCollection<GraphQLField> SelectionSet { get; }

        /// <summary>
        /// Validates the GraphQL request
        /// </summary>
        /// <param name="schema">The schema to validate against</param>
        /// <returns>Validation errors</returns>
        IEnumerable<ValidationError> Validate(GraphQLIntrospectionSchema schema);
    }
}
