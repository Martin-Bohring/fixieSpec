// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    /// <summary>
    /// And interface the provides the capabilties of an audio source.
    /// </summary>
    public interface IAudioSource
    {
        /// <summary>
        /// Starts audio recording of the audio recording source
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the audio recording started sucessful; <see langword="false"/> otherwise.
        /// </returns>
        bool StartRecording();
    }
}
