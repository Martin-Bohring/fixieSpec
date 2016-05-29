﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;

    using Shouldly;

    public abstract class DeviceBaseTests
    {
        public void ShouldFailWhenConstructedUsingNullDeviceId()
        {
            Action act = () => CreateDevice(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Input(DeviceRole.Background)]
        [Input(DeviceRole.Playback)]
        [Input(DeviceRole.Recording)]
        [Input(DeviceRole.Communication)]
        [Input(DeviceRole.Prompt)]
        [Input(DeviceRole.Alert)]
        public void ShouldNotBeAvailableWhenInRole(DeviceRole roleToAssume)
        {
            var device = CreateDevice(new DeviceId());

            device.SelectFor(roleToAssume);

            device.IsAvailable().ShouldBeFalse();
        }

        public void ShouldBeAvailableWhenInNoRole()
        {
            var device = CreateDevice(new DeviceId());

            device.SelectFor(DeviceRole.Idle);

            device.IsAvailable().ShouldBeTrue();
        }

        protected abstract DeviceBase CreateDevice(DeviceId id);
    }
}
