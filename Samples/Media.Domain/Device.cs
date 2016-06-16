﻿// <copyright>
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
        DeviceRole roleInActivity = DeviceRole.Idle;
        ActivityId currentActiviy;

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
            roleInActivity = DeviceRole.Idle;
        }

        /// <summary>
        /// Verifies if the device is available.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the device is available; <see langword="false"/> otherwise.
        /// </returns>
        public bool IsAvailable()
        {
            return roleInActivity == DeviceRole.Idle;
        }

        /// <summary>
        /// Verifies if the device is in the role given by <paramref name="role"/>.
        /// </summary>
        /// <param name="role">
        /// The role to check for.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the device is ain the role given by <paramref name="role"/>;
        /// <see langword="false"/> otherwise.
        /// </returns>
        public bool IsInRole(DeviceRole role) => roleInActivity == role;

        /// <summary>
        /// Instructs the device to assume the role given by <paramref name="roleToAssume"/>.
        /// </summary>
        /// <param name="roleToAssume">
        /// The role the device needs to assume.
        /// </param>
        /// <param name="activity">todo: describe activity parameter on AssumeRole</param>
        /// <returns>
        /// <see langword="true"/>, if the device can assume the role; <see langword="false"/> otherwise.
        /// </returns>
        protected bool AssumeRole(DeviceRole roleToAssume, ActivityId activity)
        {
            roleInActivity = roleToAssume;
            currentActiviy = activity;
            return true;
        }
    }
}
