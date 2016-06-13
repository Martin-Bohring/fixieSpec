﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using FixieSpec;

    using Domain;
    using Domain.Recording;

    public sealed class AudioRecordingNotPossibleWithoutMicrophone
    {
        readonly Microphone microphone;

        readonly AudioRecording previousAudioRecording;
        readonly AudioRecording audioRecording;

        public AudioRecordingNotPossibleWithoutMicrophone(
            AudioRecording aPreviousAudioRecording,
            AudioRecording aNewAudioRecording,
            Microphone aMicrophone)
        {
            previousAudioRecording = aPreviousAudioRecording;
            audioRecording = aNewAudioRecording;
            microphone = aMicrophone;
        }

        public void Given_the_microphone_is_not_available()
        {
            microphone.UseForAudioRecording(previousAudioRecording.ActivityId);
        }

        public void When_attempting_to_start_the_audio_recording()
        {
            audioRecording.StartRecording(microphone);
        }

        public void Then_the_audio_recording_should_not_be_recording()
        {
            audioRecording.ShouldNotBeRecording();
        }

        [Inconclusive("Find a different way to verify if the microphone is not recording")]
        public void And_then_the_selected_microphone_is_not_used_for_recording()
        {
        }
    }
}
