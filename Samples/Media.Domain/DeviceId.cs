// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the unique id of a <see cref="Device"/>.
    /// </summary>
    public class DeviceId : ValueObject<DeviceId>
    {
        /// <summary>
        /// Represents the empty <see cref="DeviceId"/>.
        /// </summary>
        public static readonly DeviceId Empty = new DeviceId(Guid.Empty);

        readonly Guid deviceId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceId"/> class.
        /// </summary>
        public DeviceId()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceId"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the device.
        /// </param>
        DeviceId(Guid id)
        {
            deviceId = id;
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> Reflect()
        {
            yield return deviceId;
        }
    }
}
