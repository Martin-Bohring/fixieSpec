// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

using System;
using AV.Domain.MediaTypes.Audio;

namespace AV.Domain.Devices.Audio
{
    /// <summary>
    /// A class that represents a microphone.
    /// </summary>
    public abstract class Microphone : IAudioSource
    {
        /// <inheritdoc/>
        public AudioMediaType GetSourceMediaType()
        {
            return new SilenceMediaType();
        }
    }
}
