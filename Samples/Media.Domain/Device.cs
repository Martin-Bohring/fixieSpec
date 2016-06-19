// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;

    /// <summary>
    /// A base class for media devices.
    /// </summary>
    public abstract class Device
    {
        static readonly RoleInActivity None = new RoleInActivity(DeviceRole.Idle, ActivityId.Empty);

        RoleInActivity currentRoleInActivity = None;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the device.
        /// </param>
        protected Device(DeviceId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets the <see cref="Id"/> of the device.
        /// </summary>
        public DeviceId Id { get; private set; }

        /// <summary>
        /// Makes the device available.
        /// </summary>
        public void MakeAvailable()
        {
            currentRoleInActivity = None;
        }

        /// <summary>
        /// Verifies if the device is available.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the device is available; <see langword="false"/> otherwise.
        /// </returns>
        public bool IsAvailable()
        {
            return currentRoleInActivity == None;
        }

        /// <summary>
        /// Verifies if the device is in a role during an activity given by <paramref name="roleInActivty"/>.
        /// </summary>
        /// <param name="roleInActivty">
        /// The role in an activity the device playsmight be part of.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the device is ain the role;
        /// <see langword="false"/> otherwise.
        /// </returns>
        public bool IsInRole(RoleInActivity roleInActivty)
        {
            if (roleInActivty == null)
            {
                throw new ArgumentNullException(nameof(roleInActivty));
            }

            return currentRoleInActivity == roleInActivty;
        }

        /// <summary>
        /// Attempts to assume a role in an activty given by <paramref name="roleInActivty"/>
        /// </summary>
        /// <param name="roleInActivty">
        /// The role in an activty the device should to assume.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the device can assume the role; <see langword="false"/> otherwise.
        /// </returns>
        protected bool AssumeRole(RoleInActivity roleInActivty)
        {
            currentRoleInActivity = roleInActivty;
            return true;
        }
    }
}
