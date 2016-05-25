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
        DeviceRole roleInActivity = DeviceRole.Idle;

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

        /// <summary>
        /// Makes the device available.
        /// </summary>
        public void MakeAvailable()
        {
            roleInActivity = DeviceRole.Idle;
        }

        /// <summary>
        /// Verifies if the device is available.
        /// </summary>
        /// <returns></returns>
        public bool IsAvailable()
        {
            return roleInActivity == DeviceRole.Idle;
        }

        /// <summary>
        /// Selects the device to assume the role given by <paramref name="roleToAssume"/>.
        /// </summary>
        /// <param name="roleToAssume">
        /// The role the device needs to assume.
        /// </param>
        public void SelectFor(DeviceRole roleToAssume)
        {
            roleInActivity = roleToAssume;
        }
    }
}
