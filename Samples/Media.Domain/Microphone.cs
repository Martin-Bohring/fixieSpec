// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// Represents a microphone.
    /// </summary>
    public class Microphone : DeviceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Microphone"/> class.
        /// </summary>
        public Microphone()
            : base(new DeviceId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Microphone"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the microphone.
        /// </param>
        public Microphone(DeviceId id)
            : base(id)
        {
        }

        /// <inheritdoc/>
        public override bool SelectFor(DeviceRole roleToAssume)
        {
            if (IsAvailable())
            {
                return base.SelectFor(roleToAssume);
            }

            return false;
        }
    }
}
