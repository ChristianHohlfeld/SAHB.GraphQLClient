﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SAHB.GraphQLClient.FieldBuilder;
using SAHB.GraphQLClient.Filtering;

namespace SAHB.GraphQL.Client.Filtering
{
    public class QueryGeneratorFilter
    {
        public Func<GraphQLField, bool> GetFilter<T>(Expression<Func<T, object>> expression)
        {
            var memberNames = ExpressionHelper.GetMemberNamesFromExpression(expression);
            var queryGeneratorField = new QueryGeneratorField(memberNames);
            return queryGeneratorField.GetFunc();
        }

        private class QueryGeneratorField
        {
            private readonly IEnumerable<string> memberNames;

            public QueryGeneratorField(IEnumerable<string> memberNames)
            {
                this.memberNames = memberNames;
            }

            public Func<GraphQLField, bool> GetFunc()
            {
                return field => ValidateField(field);
            }

            public bool ValidateField(GraphQLField field)
            {
                return memberNames.Any(memberName =>
                    memberName.Equals(field.Path) ||
                    memberName.StartsWith(field.Path + "."));
            }
        }
    }
}