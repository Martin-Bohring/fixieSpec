// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>


namespace Media.Specifications
{
    using Domain;

    public abstract class VoiceMemoRecordingSpecificationBase
    {
        protected readonly Microphone microphone = new Microphone();

        protected readonly MediaRecording voiceMemoRecording;

        protected VoiceMemoRecordingSpecificationBase()
        {
            voiceMemoRecording = new MediaRecording(microphone);
        }
    }
}
