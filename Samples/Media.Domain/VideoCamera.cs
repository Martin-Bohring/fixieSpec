﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// Represents a video camera.
    /// </summary>
    public class VideoCamera : DeviceBase, IVideoSource
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
        public bool StartRecording()
        {
            if (IsAvailable())
            {
                return AssumeRole(DeviceRole.Recording);
            }

            return false;
        }
    }
}
