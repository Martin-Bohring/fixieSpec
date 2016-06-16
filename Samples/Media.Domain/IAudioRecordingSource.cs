// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// An interface that describes an audio recording source
    /// providing audio signals to be recorded.
    /// </summary>
    public interface IAudioRecordingSource
    {
        /// <summary>
        /// Uses the audio recording source for audio recording.
        /// </summary>
        /// <param name="audioRecording">
        /// The <see cref="ActivityId"/> of the audio recording that wants to use
        /// microphone
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the audio recording source is
        /// used for audio recording; <see langword="false"/> otherwise.
        /// </returns>
        /// <remarks>
        /// Still not a good name, but the best I can find for now.
        /// </remarks>
        bool UseForAudioRecording(ActivityId audioRecording);
    }
}
