// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording
{
    using System;

    /// <summary>
    /// Represents an ongoing video recording.
    /// </summary>
    public class VideoRecording
    {
        IVideoRecordingSource videoSource;

        /// <summary>
        /// Start the video recording using the video recording device.
        /// </summary>
        /// <param name="videoSource">
        /// The device providing the video signal to be recorded.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the video recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        public bool StartRecording(IVideoRecordingSource videoSource)
        {
            if (videoSource == null)
            {
                throw new ArgumentNullException(nameof(videoSource));
            }

            if (videoSource.UseForVideoRecording())
            {
                this.videoSource = videoSource;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies if the video recording is active.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the video recording is recording; <see langword="false"/> otherwise.
        /// </returns>
        public bool IsRecording() => videoSource != null;
    }
}
