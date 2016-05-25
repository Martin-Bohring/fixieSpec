// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// A base class for media devices.
    /// </summary>
    public abstract class DeviceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceBase"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the device.
        /// </param>
        protected DeviceBase(DeviceId id)
        {
            DeviceId = id;
        }

        /// <summary>
        /// Gets the <see cref="DeviceId"/> of the device.
        /// </summary>
        public DeviceId DeviceId { get; private set; }
    }
}
