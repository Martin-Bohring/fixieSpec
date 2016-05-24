// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Audio
{
    /// <summary>
    /// A headset is a device combining a speaker and a microphone.
    /// </summary>
    public class Headset : IConsumeAudio, IProduceAudio
    {
        public bool CanConsume(AudioMediaType audioMedia)
        {
            return false;
        }

        public AudioMediaType GetSourceMediaType()
        {
            return new SilenceMediaType();
        }
    }
}
