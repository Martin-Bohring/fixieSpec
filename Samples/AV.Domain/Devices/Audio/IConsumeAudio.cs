// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Devices.Audio
{
    using MediaTypes.Audio;

    /// <summary>
    /// A consumer of audio media types.
    /// </summary>
    public interface IConsumeAudio
    {
        /// <summary>
        /// Indicates if the audio media type given by <paramref name="audioMedia"/> can be consumed.
        /// </summary>
        /// <param name="audioMedia">
        /// The <see cref="AudioMediaType"/> to be consumed.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the audio media given by <paramref name="audioMedia"/> can be consumed;
        /// <see langword="false"/> otherwise.
        /// </returns>
        bool CanConsume(AudioMediaType audioMedia);
    }
}
