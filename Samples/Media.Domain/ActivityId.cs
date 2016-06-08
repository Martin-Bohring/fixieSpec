// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;

    /// <summary>
    /// Represents the unique id of an activity.
    /// </summary>
    public class ActivityId : IEquatable<ActivityId>
    {
        readonly Guid activityId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityId"/> class.
        /// </summary>
        public ActivityId()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityId"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the activity.
        /// </param>
        public ActivityId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid device id", nameof(id));
            }

            activityId = id;
        }

        /// <inheritdoc/>
        public bool Equals(ActivityId other)
        {
            return activityId == other.activityId;
        }
    }
}
