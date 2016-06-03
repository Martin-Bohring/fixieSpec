// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Shouldly;

    using Domain;
    using Domain.Recording;

    public sealed class SucessfulAudioRecordingSpecification
    {
        readonly Microphone microphone = new Microphone();

        readonly AudioRecording audioRecording = new AudioRecording();

        public void Given_a_microphone_is_available()
        {
            microphone.MakeAvailable();
        }

        public void When_the_voice_memo_recording_is_started()
        {
            audioRecording.StartRecording(microphone);
        }

        public void Then_the_voice_recording_should_be_recording()
        {
            audioRecording.ShouldBeRecording();
        }

        public void And_then_the_selected_microphone_is_used_for_recording()
        {
            microphone.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        public void And_then_the_selected_microphone_is_not_available_anymore()
        {
            microphone.IsAvailable().ShouldBeFalse();
        }
    }
}
