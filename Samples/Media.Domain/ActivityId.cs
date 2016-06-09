// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the unique id of an activity.
    /// </summary>
    public class ActivityId : ValueObject<ActivityId>
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
                throw new ArgumentException("Invalid activity id", nameof(id));
            }

            activityId = id;
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> Reflect()
        {
            yield return activityId;
        }
    }
}
