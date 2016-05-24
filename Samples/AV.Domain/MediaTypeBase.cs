// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes
{
    /// <summary>
    /// A base class for media types.
    /// </summary>
    public abstract class MediaTypeBase
    {
        /// <summary>
        /// Gets a value indicating whether this is a life media type.
        /// </summary>
        public abstract bool IsLive { get; }
    }
}
