// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;

    /// <summary>
    /// Represents a video camera.
    /// </summary>
    public class VideoCamera : Device, IVideoRecordingSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCamera"/> class.
        /// </summary>
        public VideoCamera()
            : base(new DeviceId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCamera"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the video camera device.
        /// </param>
        public VideoCamera(DeviceId id)
            : base(id)
        {
        }

        /// <inheritdoc/>
        public bool UseForVideoRecording(ActivityId videoRecording)
        {
            if (videoRecording == null)
            {
                throw new ArgumentNullException(nameof(videoRecording));
            }

            if (IsAvailable())
            {
                return AssumeRole(RoleInActivity.Recording(videoRecording));
            }

            return false;
        }
    }
}
