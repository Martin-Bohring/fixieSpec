// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;

    /// <summary>
    /// Represents a microphone.
    /// </summary>
    public sealed class Microphone : Device, IAudioRecordingSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Microphone"/> class.
        /// </summary>
        public Microphone()
            : base(new DeviceId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Microphone"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the microphone.
        /// </param>
        public Microphone(DeviceId id)
            : base(id)
        {
        }

        /// <inheritdoc/>
        public bool UseForAudioRecording(ActivityId audioRecording)
        {
            if (audioRecording == null)
            {
                throw new ArgumentNullException(nameof(audioRecording));
            }

            if (IsAvailable())
            {
                return AssumeRole(RoleInActivity.Recording(audioRecording));
            }

            return false;
        }

        /// <inheritdoc/>
        public bool StopUsingForAudioRecording(ActivityId audioRecording)
        {
            if (audioRecording == null)
            {
                throw new ArgumentNullException(nameof(audioRecording));
            }

            if (IsAudioRecording(audioRecording))
            {
                MakeAvailable();
                return true;
            }

            return false;
        }

        bool IsAudioRecording(ActivityId audioRecording)
        {
            return IsInRole(RoleInActivity.Recording(audioRecording));
        }
    }
}
