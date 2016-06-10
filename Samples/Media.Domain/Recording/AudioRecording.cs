﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording
{
    using System;

    /// <summary>
    /// Represents an ongoing audio recording.
    /// </summary>
    public class AudioRecording : IMediaRecording, IActivity
    {
        IAudioRecordingSource audioSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecording"/> class.
        /// </summary>
        public AudioRecording()
            : this(new ActivityId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecording"/> class.
        /// </summary>
        /// <param name="activityId">
        /// The unique <see cref="ActivityId"/> of this audio recording activity.
        /// </param>
        public AudioRecording(ActivityId activityId)
        {
            if (activityId == null)
            {
                throw new ArgumentNullException(nameof(activityId));
            }

            ActivityId = activityId;
        }

        /// <inheritdoc/>
        public ActivityId ActivityId { get; private set; }

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
