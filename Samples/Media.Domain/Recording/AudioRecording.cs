// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording
{
    using System;

    /// <summary>
    /// Represents an ongoing audio recording.
    /// </summary>
    public class AudioRecording
    {
        readonly DeviceBase audioSource;
        bool isRecording;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecording"/> class.
        /// </summary>
        /// <param name="audioSource">
        /// The device providing the audio signal to be recorded.
        /// </param>
        public AudioRecording(DeviceBase audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            this.audioSource = audioSource;
        }

        /// <summary>
        /// Start the audio recording using the audio source device.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the media recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        public bool StartRecording()
        {
            isRecording = audioSource.SelectFor(DeviceRole.Recording);
            return isRecording;
        }

        /// <summary>
        /// Verifies if the audio recording is active.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the audio recording is recording; <see langword="false"/> otherwise.
        /// </returns>
        public bool IsRecording() => isRecording;
    }
}
