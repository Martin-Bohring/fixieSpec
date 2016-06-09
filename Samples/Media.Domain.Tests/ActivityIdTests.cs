// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public sealed class ActivityIdTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();

            var guardsConstructorsAssertion = new GuardClauseAssertion(fixture);

            guardsConstructorsAssertion.Verify(typeof(ActivityId).GetConstructors());
        }

        public void ShouldHaveValueSemantics()
        {
            var fixture = new Fixture();

            var equalitySemanticAssertion = new CompositeIdiomaticAssertion(
                new EqualsNewObjectAssertion(fixture),
                new EqualsNullAssertion(fixture),
                new EqualsSelfAssertion(fixture),
                new EqualsSuccessiveAssertion(fixture));

            equalitySemanticAssertion.Verify(typeof(ActivityId));
        }

        public void ShouldCorrectlyCalculateHashCode()
        {
            var fixture = new Fixture();

            var calculatesHashCodeAssertion = new GetHashCodeSuccessiveAssertion(fixture);

            calculatesHashCodeAssertion.Verify(typeof(ActivityId));
        }
    }
}
