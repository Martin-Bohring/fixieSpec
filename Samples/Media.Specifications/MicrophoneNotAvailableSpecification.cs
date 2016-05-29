// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Domain;
    using Shouldly;

    public class MicrophoneNotAvailableSpecification : VoiceMemoRecordingSpecificationBase
    {
        public void Given_the_microphone_is_not_available()
        {
            microphone.SelectFor(DeviceRole.Communication);
        }

        public void When_the_voice_recording_is_started()
        {
            voiceMemoRecording.StartRecording();
        }

        public void Then_the_voice_recording_should_not_be_recording()
        {
            voiceMemoRecording.IsRecording().ShouldBeFalse();
        }

        public void And_then_the_selected_microphone_is_not_used_for_recording()
        {
            microphone.IsInRole(DeviceRole.Recording).ShouldBeFalse();
        }
    }
}
