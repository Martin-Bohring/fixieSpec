// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Devices.Audio
{
    /// <summary>
    /// A headset is a device combining a speaker and a microphone.
    /// </summary>
    public class Headset
    {
        readonly Speaker headsetSpeaker;
        readonly Microphone headsetMicrophone;

        public Headset (Microphone headsetMicrophone, Speaker headsetSpeaker)
        {
            this.headsetMicrophone = headsetMicrophone;
            this.headsetSpeaker = headsetSpeaker;
        }
    }
}
