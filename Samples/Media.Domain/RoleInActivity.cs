// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a role within an activity.
    /// </summary>
    public class RoleInActivity : ValueObject<RoleInActivity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleInActivity"/> class.
        /// </summary>
        /// <param name="role">
        /// The role within the activity.
        /// </param>
        /// <param name="activity">
        /// The activity a role.
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
        /// Gets the activity a role is being played in.
        /// </summary>
        public ActivityId Activity { get; private set; }

        /// <summary>
        /// Gets the role within the activity.
        /// </summary>
        public DeviceRole Role { get; private set; }

        /// <inheritdoc/>
        protected override IEnumerable<object> Reflect()
        {
            yield return Role;
            yield return Activity;
        }
    }
}
