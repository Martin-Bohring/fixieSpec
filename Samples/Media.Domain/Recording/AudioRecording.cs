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
    public class AudioRecording : IMediaRecording
    {
        IAudioRecordingSource audioSource;

        /// <summary>
        /// Start the audio recording using the audio source device.
        /// </summary>
        /// <param name="audioSource">
        /// The device providing the audio signal to be recorded.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the audio recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        public bool StartRecording(IAudioRecordingSource audioSource)
        {
            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            if (audioSource.UseForAudioRecording())
            {
                this.audioSource = audioSource;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool IsRecording() => audioSource != null;
    }
}
