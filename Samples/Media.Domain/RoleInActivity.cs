// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a role during an activity.
    /// </summary>
    public sealed class RoleInActivity : ValueObject<RoleInActivity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleInActivity"/> class.
        /// </summary>
        /// <param name="role">
        /// The role during the activity.
        /// </param>
        /// <param name="activity">
        /// The activity during that the role is played.
        /// </param>
        public RoleInActivity(DeviceRole role, ActivityId activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            Role = role;
            Activity = activity;
        }

        /// <summary>
        /// Gets the activity during that the role is being played.
        /// </summary>
        public ActivityId Activity { get; }

        /// <summary>
        /// Gets the role during the activity.
        /// </summary>
        public DeviceRole Role { get; }

        /// <summary>
        /// Creates a <see cref="RoleInActivity"/> instance indicating a recording role.
        /// during an activity.
        /// </summary>
        /// <param name="activity">
        /// The activity during that the the recording happens.
        /// </param>
        /// <returns>
        /// The <see cref="RoleInActivity"/> instance indicating a recording role.
        /// </returns>
        public static RoleInActivity Recording(ActivityId activity)
        {
            return new RoleInActivity(DeviceRole.Recording, activity);
        }

        /// <summary>
        /// Creates a <see cref="RoleInActivity"/> instance indicating no role.
        /// during an activity.
        /// </summary>
        /// <returns>
        /// The <see cref="RoleInActivity"/> instance indicating no role.
        /// </returns>
        public static RoleInActivity None()
        {
            return new RoleInActivity(DeviceRole.Idle, ActivityId.Empty);
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> Reflect()
        {
            yield return Role;
            yield return Activity;
        }
    }
}
