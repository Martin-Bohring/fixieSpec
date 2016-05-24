// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Video
{
    /// <summary>
    /// a class that represents a recorded video media type.
    /// </summary>
    public class RecordedVideoMediaType : VideoMediaType
    {
        /// <inheritdoc/>
        public override bool IsLive => false;
    }
}
