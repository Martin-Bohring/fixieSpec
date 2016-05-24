// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Audio
{
    /// <summary>
    /// A class that represents a speaker.
    /// </summary>
    public abstract class Speaker : IConsumeAudio
    {
        public bool CanConsume(AudioMediaType audioMedia)
        {
            return false;
        }
    }
}
