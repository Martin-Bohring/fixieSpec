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
        protected DeviceBase(DeviceId id)
        {
            DeviceId = id;
        }

        public DeviceId DeviceId { get; private set; }
    }
}
