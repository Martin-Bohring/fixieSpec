// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// An interface that describes a video recording source
    /// providing video signals to be recorded.
    /// </summary>
    public interface IVideoRecordingSource
    {
        /// <summary>
        /// Uses the video recording source for video recording.
        /// </summary>
        /// <param name="videoRecording">
        /// The <see cref="ActivityId"/> of the video recording that wants to use
        /// the video recording source
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the video recording source is
        /// used for video recording; <see langword="false"/> otherwise.
        /// </returns>
        /// <remarks>
        /// Still not a good name, but the best I can find for now.
        /// </remarks>
        bool UseForVideoRecording(ActivityId videoRecording);
    }
}
