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
    public class VideoRecording : IMediaRecording
    {
        IVideoRecordingSource videoSource;
        IAudioRecordingSource audioSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRecording"/> class.
        /// </summary>
        public VideoRecording()
            : this(new ActivityId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRecording"/> class.
        /// </summary>
        /// <param name="activityId">
        /// The unique <see cref="ActivityId"/> of this video recording activity.
        /// </param>
        public VideoRecording(ActivityId activityId)
        {
            if (activityId == null)
            {
                throw new ArgumentNullException(nameof(activityId));
            }

            ActivityId = activityId;
        }

        /// <inheritdoc/>
        public ActivityId ActivityId { get; }

        /// <summary>
        /// Start the video recording using the video and audio recording sources.
        /// </summary>
        /// <param name="videoSource">
        /// The device providing the video signal to be recorded.
        /// </param>
        /// <param name="audioSource">
        /// The device providing the audio signal to be recorded
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the video recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        public bool StartRecording(IVideoRecordingSource videoSource, IAudioRecordingSource audioSource)
        {
            if (videoSource == null)
            {
                throw new ArgumentNullException(nameof(videoSource));
            }

            if (audioSource == null)
            {
                throw new ArgumentNullException(nameof(audioSource));
            }

            if (videoSource.UseForVideoRecording(ActivityId) && audioSource.UseForAudioRecording(ActivityId))
            {
                this.videoSource = videoSource;
                this.audioSource = audioSource;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Start the video recording using the video recording source given by <paramref name="videoSource"/>.
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

            if (videoSource.UseForVideoRecording(ActivityId))
            {
                this.videoSource = videoSource;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool IsRecording() => videoSource != null;
    }
}
