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
        readonly DeviceBase videoSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRecording"/> class.
        /// </summary>
        /// <param name="videoSource">
        /// The device providing the video signal to be recorded.
        /// </param>
        public VideoRecording(DeviceBase videoSource)
        {
            if (videoSource == null)
            {
                throw new ArgumentNullException(nameof(videoSource));
            }

            this.videoSource = videoSource;
        }
    }
}
