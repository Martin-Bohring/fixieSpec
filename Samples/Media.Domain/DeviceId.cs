// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;

    /// <summary>
    /// Represents the unique id of a <see cref="Device"/>.
    /// </summary>
    public class DeviceId : IEquatable<DeviceId>
    {
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
        public DeviceId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid device id", nameof(id));
            }

            deviceId = id;
        }

        /// <summary>
        /// The equality operator.
        /// </summary>
        /// <param name="lhs">
        /// The left hand side of the operator.
        /// </param>
        /// <param name="rhs">
        /// The right hand side of the operator.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the values of its operands are equal; <see langword="false"/> otherwise.
        /// </returns>
        public static bool operator ==(DeviceId lhs, DeviceId rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return true;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// The inequality operator.
        /// </summary>
        /// <param name="lhs">
        /// The left hand side of the operator.
        /// </param>
        /// <param name="rhs">
        /// The right hand side of the operator.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the values of its operands are not equal; <see langword="false"/> otherwise.
        /// </returns>
        public static bool operator !=(DeviceId lhs, DeviceId rhs) => !(lhs == rhs);

        /// <inheritdoc/>
        public bool Equals(DeviceId other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return deviceId == other.deviceId;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            var other = obj as DeviceId;

            return Equals(other);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return deviceId.GetHashCode();
        }
    }
}
