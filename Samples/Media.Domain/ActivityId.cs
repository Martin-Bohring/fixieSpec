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
        /// <summary>
        /// Represents the empty <see cref="ActivityId"/>.
        /// </summary>
        public static readonly ActivityId Empty = new ActivityId(Guid.Empty);

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
        ActivityId(Guid id)
        {
            activityId = id;
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> Reflect()
        {
            yield return activityId;
        }
    }
}
