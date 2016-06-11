// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Shouldly;

    using Domain;
    using Domain.Recording;

    using Media.Specifications;

    public sealed class SucessfulAudioRecording
    {
        readonly Microphone microphone;

        readonly AudioRecording audioRecording;

        public SucessfulAudioRecording(
            AudioRecording anAudioRecording,
            Microphone aMicrophone)
        {
            audioRecording = anAudioRecording;
            microphone = aMicrophone;
        }

        public void Given_a_microphone_is_available()
        {
            microphone.MakeAvailable();
        }

        public void When_the_audio_recording_is_started()
        {
            audioRecording.StartRecording(microphone);
        }

        public void Then_the_audio_recording_should_be_recording()
        {
            audioRecording.ShouldBeRecording();
        }

        public void And_then_the_selected_microphone_is_used_for_recording()
        {
            microphone.ShouldBeRecording();
        }

        public void And_then_the_selected_microphone_is_not_available_anymore()
        {
            microphone.IsAvailable().ShouldBeFalse();
        }
    }
}
