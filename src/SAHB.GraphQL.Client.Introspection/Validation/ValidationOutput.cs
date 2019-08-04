﻿using SAHB.GraphQLClient.FieldBuilder;
using System;

namespace SAHB.GraphQL.Client.Introspection.Validation
{
    public class ValidationOutput
    {
        public ValidationOutput(ValidationType validationType, GraphQLOperationType operationType)
        {
            this.ValidationType = validationType;
            this.OperationType = operationType;
        }

        public ValidationOutput(string path, ValidationType validationType, GraphQLField field)
        {
            this.Path = path;
            this.ValidationType = validationType;
            this.Field = field;
        }

        public ValidationOutput(string path, ValidationType validationType, GraphQLField field, string expected, string actual)
        {
            this.Path = path;
            this.ValidationType = validationType;
            this.Field = field;
            this.Expected = expected;
            this.Actual = actual;
        }

        internal string Path { get; }
        public ValidationType ValidationType { get; }
        internal GraphQLField Field { get; }
        internal string Expected { get; }
        public string Actual { get; }
        internal GraphQLOperationType OperationType { get; }

        public string Message {
            get
            {
                switch (ValidationType)
                {
                    case ValidationType.Argument_Invalid_Type:
                        return $"Argument at {Path} has a invalid type. Expected is {Expected}, actual is {Actual}.";
                    case ValidationType.Argument_Not_Found:
                        return $"Argument at {Path} was not found";
                    case ValidationType.Field_Cannot_Have_SelectionSet:
                        return $"Field at {Path} cannot have a selectionSet";
                    case ValidationType.Field_Deprecated:
                        return $"Field at {Path} is deprecated";
                    case ValidationType.Field_Not_Found:
                        return $"Field at {Path} was not found";
                    case ValidationType.Field_Should_Have_SelectionSet:
                        return $"Field at {Path} should have a selectionSet";
                    case ValidationType.Operation_Type_Not_Found:
                        return $"OperationType {OperationType} was not found";
                    case ValidationType.PossibleType_Not_Found:
                        return $"Possible type at {Path} was not found";
                    default:
                        throw new NotImplementedException($"ValidationType {ValidationType} not implemented");
                }
            }
        }
    }
}
