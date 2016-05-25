// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Domain;

    using FixieSpec;
    using Shouldly;

    public class VoiceMemoRecordingSpecification
    {
        readonly Microphone microphone = new Microphone();

        public void Given_a_microphone_is_available()
        {
            microphone.MakeAvailable();
        }

        public void When_the_microphone_is_selected_for_voice_memo_recording()
        {
            microphone.SelectFor(DeviceRole.Recording);
        }

        public void And_when_the_voice_memo_recording_is_started()
        {
        }

        [Inconclusive]
        public void Then_the_selected_microphone_is_used_for_recording()
        {
        }

        public void And_then_the_microphone_is_not_available_anymore()
        {
            microphone.IsAvailable().ShouldBeFalse();
        }
    }
}
