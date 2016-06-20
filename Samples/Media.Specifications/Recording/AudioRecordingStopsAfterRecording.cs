// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Domain;
    using Domain.Recording;
    using Shouldly;

    public sealed class AudioRecordingStopsAfterRecording
    {
        readonly Microphone microphone;

        readonly AudioRecording audioRecording;

        public AudioRecordingStopsAfterRecording(
            AudioRecording anAudioRecording,
            Microphone aMicrophone)
        {
            audioRecording = anAudioRecording;
            microphone = aMicrophone;
        }

        public void Given_an_audio_recording_is_started()
        {
            audioRecording.StartRecording(microphone);
        }

        public void When_the_audio_recording_is_stopped()
        {
            audioRecording.StopRecording();
        }

        public void Then_the_audio_recording_is_no_more_recording()
        {
            audioRecording.ShouldNotBeRecording();
        }

        public void And_then_the_microphone_is_available_again()
        {
            microphone.IsAvailable().ShouldBeTrue();
        }
    }
}
