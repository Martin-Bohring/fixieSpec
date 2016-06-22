// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public sealed class DevicesTests
    {
        public void ShouldRegisterANewDevice(
            Devices devices,
            Microphone newDevice)
        {
            devices.RegisterNewDevice(newDevice).ShouldBeTrue();
        }

        public void ShouldNotRegisterAnAlreadyRegisteredDevice(
            Devices devices,
            Microphone newDevice)
        {
            devices.RegisterNewDevice(newDevice);

            devices.RegisterNewDevice(newDevice).ShouldBeFalse();
        }

        public void ShouldFindDevicesByType(
            Devices devices,
            Microphone aDevice,
            VideoCamera anotherDevice)
        {
            devices.RegisterNewDevice(aDevice);
            devices.RegisterNewDevice(anotherDevice);

            devices.FindDevicesByType<Microphone>().ShouldContain(aDevice);
        }

        public void ShouldNotFindDevicesByTypeWhenNoDevicesRegistered(Devices devices)
        {
            devices.FindDevicesByType<Microphone>().ShouldBeEmpty();
        }
    }
}
