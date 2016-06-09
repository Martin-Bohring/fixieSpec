// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public sealed class DeviceIdTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();

            var expectation = new GuardClauseAssertion(fixture);

            expectation.Verify(typeof(DeviceId).GetConstructors());
        }
    }
}
