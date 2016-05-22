﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Devices.Audio
{
    using MediaTypes.Audio;

    /// <summary>
    /// A souce of audio media types.
    /// </summary>
    public interface IAudioSource
    {
        /// <summary>
        /// Gets the <see cref="AudioMediaType"/> the audio source is currently creating.
        /// </summary>
        /// <returns></returns>
        AudioMediaType GetSourceMediaType();
    }
}
