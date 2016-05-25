// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain
{
    /// <summary>
    /// Describes the state of a media device.
    /// </summary>
    public enum DeviceState
    {
        /// <summary>
        /// The device is connected.
        /// </summary>
        Connected,

        /// <summary>
        /// The device has been connected once, but is not right now.
        /// </summary>
        Disconnected
    }
}
