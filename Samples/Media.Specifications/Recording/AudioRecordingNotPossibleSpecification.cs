// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Shouldly;
    using FixieSpec;

    using Domain;
    using Domain.Recording;

    public sealed class AudioRecordingNotPossibleSpecification
    {
        readonly Microphone microphone = new Microphone();

        readonly AudioRecording audioRecording;

        public AudioRecordingNotPossibleSpecification()
        {
            audioRecording = new AudioRecording();
        }
        public void Given_the_microphone_is_not_available()
        {
            microphone.UseForAudioRecording();
        }

        public void When_attempting_to_start_the_audio_recording()
        {
            audioRecording.StartRecording(microphone);
        }

        public void Then_the_audio_recording_should_not_be_recording()
        {
            audioRecording.IsRecording().ShouldBeFalse();
        }

        [Inconclusive("Find a different way to verify if the microphone is recording")]
        public void And_then_the_selected_microphone_is_not_used_for_recording()
        {
        }
    }
}
