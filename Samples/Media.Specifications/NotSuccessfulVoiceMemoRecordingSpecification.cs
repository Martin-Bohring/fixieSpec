// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Domain;

    using FixieSpec;
    using Shouldly;

    public class NotSuccessfulVoiceMemoRecordingSpecification
    {
        readonly Microphone microphone = new Microphone();

        MediaRecording voiceMemoRecording;

        public void Given_a_microphone_is_not_available()
        {
            microphone.SelectFor(DeviceRole.Communication);
        }

        public void When_the_microphone_is_used_for_voice_memo_recording()
        {
            voiceMemoRecording = new MediaRecording(microphone);
        }

        public void And_when_the_voice_memo_recording_is_started()
        {
            voiceMemoRecording.StartRecording();
        }

        [Inconclusive]
        public void Then_the_media_recording_could_not_be_started()
        {
        }

        [Inconclusive]
        public void And_then_the_selected_microphone_is_not_used_for_recording()
        {
            microphone.IsInRole(DeviceRole.Recording).ShouldBeFalse();
        }
    }
}
