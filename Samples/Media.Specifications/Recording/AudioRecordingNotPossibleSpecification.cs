﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Shouldly;

    using Domain;
    using Domain.Recording;
    public sealed class AudioRecordingNotPossibleSpecification
    {
        readonly Microphone microphone = new Microphone();

        readonly AudioRecording audioRecording;

        public AudioRecordingNotPossibleSpecification()
        {
            audioRecording = new AudioRecording(microphone);
        }
        public void Given_the_microphone_is_not_available()
        {
            microphone.SelectFor(DeviceRole.Communication);
        }

        public void When_attempting_to_start_the_voice_memo_recording()
        {
            audioRecording.StartRecording();
        }

        public void Then_the_voice_recording_should_not_be_recording()
        {
            audioRecording.IsRecording().ShouldBeFalse();
        }

        public void And_then_the_selected_microphone_is_not_used_for_recording()
        {
            microphone.IsInRole(DeviceRole.Recording).ShouldBeFalse();
        }
    }
}
