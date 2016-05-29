// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;

    /// <summary>
    /// Represents an ongoing media recording.
    /// </summary>
    public class MediaRecording
    {
        readonly DeviceBase mediaSource;
        bool isRecording;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaRecording"/> class.
        /// </summary>
        /// <param name="mediaSource">
        /// The device providing the media to be recorded.
        /// </param>
        public MediaRecording(DeviceBase mediaSource)
        {
            if (mediaSource == null)
            {
                throw new ArgumentNullException(nameof(mediaSource));
            }

            this.mediaSource = mediaSource;
        }

        /// <summary>
        /// Start the media recording using the media source device.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the media recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        public bool StartRecording()
        {
            isRecording = mediaSource.SelectFor(DeviceRole.Recording);
            return isRecording;
        }

        /// <summary>
        /// Verfies if the media recording is active.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the media recording is recording; <see langword="false"/> otherwise.
        /// </returns>
        public bool IsRecording() => isRecording;
    }
}
