// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// An interface that allows to identify an ongoing activity.
    /// </summary>
    public interface IActivity
    {
        /// <summary>
        /// Gets the unique <see cref="ActivityId"/> of the activity.
        /// </summary>
        ActivityId ActivityId { get; }
    }
}
