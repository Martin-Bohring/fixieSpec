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
        readonly IVideoSource videoSource;
        bool isRecording;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRecording"/> class.
        /// </summary>
        /// <param name="videoSource">
        /// The device providing the video signal to be recorded.
        /// </param>
        public VideoRecording(IVideoSource videoSource)
        {
            if (videoSource == null)
            {
                throw new ArgumentNullException(nameof(videoSource));
            }

            this.videoSource = videoSource;
        }

        /// <summary>
        /// Start the audio recording using the video recording device.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the media recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        public bool StartRecording()
        {
            isRecording = videoSource.StartRecording();
            return isRecording;
        }

        /// <summary>
        /// Verifies if the video recording is active.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the audio recording is recording; <see langword="false"/> otherwise.
        /// </returns>
        public bool IsRecording() => isRecording;
    }
}
