// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;

    using Shouldly;

    public sealed class DeviceIdTests
    {
        public void ShouldFailWhenConstructedUsingEmptyId()
        {
            Action act = () => new DeviceId(Guid.Empty);

            act.ShouldThrow<ArgumentException>();
        }

        public void ShouldSucceedWhenConstructedWithValidId()
        {
            Action act = () => new DeviceId(Guid.NewGuid());

            act.ShouldNotThrow();
        }

        public void ShouldSucceedWhenConstructedWithoutId()
        {
            Action act = () => new DeviceId();

            act.ShouldNotThrow();
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

        public void ShouldBeEqualWithSameInstance()
        {
            var deviceId = new DeviceId(Guid.NewGuid());

#pragma warning disable RECS0088 // Comparing equal expression for equality is usually useless
            deviceId.Equals(deviceId).ShouldBeTrue();
#pragma warning restore RECS0088 // Comparing equal expression for equality is usually useless
        }
    }
}
