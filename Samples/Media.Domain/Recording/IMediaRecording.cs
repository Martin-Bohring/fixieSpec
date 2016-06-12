// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording
{
    /// <summary>
    /// Represents a media recording
    /// </summary>
    public interface IMediaRecording : IActivity
    {
        /// <summary>
        /// Verifies if recording is active.
        /// </summary>
        /// <returns>
        /// <see langword="true"/>, if the audio recording is recording; <see langword="false"/> otherwise.
        /// </returns>
        bool IsRecording();
    }
}