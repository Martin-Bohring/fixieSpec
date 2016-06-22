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

        public void ShouldNotFindDevicesByTypeWhenNoDevicesAreRegistered(
            Devices devices)
        {
            devices.FindDevicesByType<Microphone>().ShouldBeEmpty();
        }

        public void ShouldNotFindDeviceByIdWhenNoDeviceAreRegistered
            (Devices devices,
             DeviceId anyDeviceId)
        {
            Device notFoundDevice = null;

            devices.FindDeviceById(anyDeviceId, out notFoundDevice).ShouldBeFalse();
            notFoundDevice.ShouldBeNull();
        }

        public void ShouldFindDeviceByIdWhenDeviceIsRegistered(
            Devices devices,
            Microphone aDevice,
            VideoCamera anotherDevice)
        {
            devices.RegisterNewDevice(aDevice);
            devices.RegisterNewDevice(anotherDevice);
            Device foundDevice = null;

            devices.FindDeviceById(aDevice.Id, out foundDevice).ShouldBeTrue();

            foundDevice.ShouldBe(aDevice);
        }

        public void ShouldNotFindDeviceByIdWhenDeviceIsNotRegistered(
            Devices devices,
            Microphone aDevice,
            DeviceId anyDeviceId)
        {
            devices.RegisterNewDevice(aDevice);
            Device notFoundDevice = null;

            devices.FindDeviceById(anyDeviceId, out notFoundDevice).ShouldBeFalse();
            notFoundDevice.ShouldBeNull();
        }
    }
}
