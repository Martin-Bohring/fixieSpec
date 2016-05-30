// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// An interface the provides the capabilties of a video source.
    /// </summary>
    public interface IVideoSource
    {
        /// <summary>
        /// Starts video recording of the video.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the video recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        bool StartRecording();
    }
}
