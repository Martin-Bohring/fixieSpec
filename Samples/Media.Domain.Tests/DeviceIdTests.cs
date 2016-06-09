// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;
    using Shouldly;

    public sealed class DeviceIdTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();
            var expectation = new GuardClauseAssertion(fixture);

            expectation.Verify(typeof(DeviceId).GetConstructors());
        }

        public void ShouldBeEqualWithIdenticalId()
        {
            Guid identicalId = Guid.NewGuid();

            var firstDeviceId = new DeviceId(identicalId);
            var secondDeviceId = new DeviceId(identicalId);

            firstDeviceId.Equals(secondDeviceId).ShouldBeTrue();
        }

        public void ShouldNotBeEqualWithDifferentId()
        {
            var firstDeviceId = new DeviceId(Guid.NewGuid());
            var secondDeviceId = new DeviceId(Guid.NewGuid());

            firstDeviceId.Equals(secondDeviceId).ShouldBeFalse();
        }

        public void ShouldBeEqualWithSelf()
        {
            var fixture = new Fixture();
            var expectation = new EqualsSelfAssertion(fixture);

            expectation.Verify(typeof(DeviceId));
        }
    }
}
