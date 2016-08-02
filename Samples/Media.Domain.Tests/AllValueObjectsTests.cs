// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public sealed class AllValueObjectsTests
    {
        public void ShouldHaveValueSemantics()
        {
            var fixture = new Fixture();

            var equalitySemanticAssertion = new CompositeIdiomaticAssertion(
                new EqualsNewObjectAssertion(fixture),
                new EqualsNullAssertion(fixture),
                new EqualsSelfAssertion(fixture),
                new EqualsSuccessiveAssertion(fixture));

            equalitySemanticAssertion.Verify(ValueTypes());
        }

        public void ShouldCorrectlyCalculateHashCode()
        {
            var fixture = new Fixture();

            var calculatesHashCodeAssertion = new GetHashCodeSuccessiveAssertion(fixture);

            calculatesHashCodeAssertion.Verify(ValueTypes());
        }

        static IEnumerable<Type> ValueTypes()
        {
            return from type in typeof(ValueObject<>).Assembly.ConcreteTypesInAssembly()
                   let baseType = type.BaseType
                   where baseType != null && baseType.IsGenericType &&
                   baseType.GetGenericTypeDefinition() == typeof(ValueObject<>)
                   select type;
        }
    }
}
