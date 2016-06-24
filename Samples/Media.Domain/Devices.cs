// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A class that allows to access all known devices and register new devices.
    /// </summary>
    public sealed class Devices
    {
        readonly ConcurrentDictionary<DeviceId, Device> devices = new ConcurrentDictionary<DeviceId, Device>();

        /// <summary>
        /// Registers a new discovered or created device.
        /// </summary>
        /// <param name="newDevice">
        /// The new device to register.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the new device has been registered; <see langword="false"/> otherwise.
        /// </returns>
        public bool RegisterNewDevice(Device newDevice)
        {
            if (newDevice == null)
            {
                throw new ArgumentNullException(nameof(newDevice));
            }

            return devices.TryAdd(newDevice.Id, newDevice);
        }

        /// <summary>
        /// Gets all devices of type given by <typeparamref name="TDevice"/>
        /// </summary>
        /// <typeparam name="TDevice">
        /// The type of devices to find.
        /// </typeparam>
        /// <returns>
        /// All found devices of type <typeparamref name="TDevice"/>
        /// </returns>
        public IEnumerable<TDevice> FindDevicesByType<TDevice>()
        {
            return devices.Values.OfType<TDevice>();
        }

        /// <summary>
        /// Attempts to find a device by its id given by <paramref name="deviceId"/>
        /// </summary>
        /// <param name="deviceId">
        /// The id of the device to find.
        /// </param>
        /// <param name="foundDevice">
        /// The device that has been found or <see langword="null"/> if the device has not beed found.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the device has been found; <see langword="false"/> otherwise.
        /// </returns>
        public bool FindDeviceById(DeviceId deviceId, out Device foundDevice)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            return devices.TryGetValue(deviceId, out foundDevice);
        }
    }
}
