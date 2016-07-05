// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public sealed class MicrophoneTests
    {
        public void ShouldBeAvailableWhenConstructed(Microphone microphone)
        {
            microphone.IsAvailable().ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenUsedForAudioRecording(
            Microphone microphone,
            ActivityId audioRecording)
        {
            microphone.UseForAudioRecording(audioRecording);

            microphone.IsInRole(RoleInActivity.Recording(audioRecording)).ShouldBeTrue();
        }

        public void CannotUseForAudioRecordingWhenAlreadyRecording(
            Microphone microphone,
            ActivityId previousAudioRecording,
            ActivityId newAudioRecording)
        {
            microphone.UseForAudioRecording(previousAudioRecording);

            microphone.UseForAudioRecording(newAudioRecording).ShouldBeFalse();
        }

        public void ShouldBeAvailableWhenStoppingUseForAudioRecording(
            Microphone microphone,
            ActivityId audioRecording)
        {
            microphone.UseForAudioRecording(audioRecording);

            microphone.StopUsingForAudioRecording(audioRecording);

            microphone.IsAvailable().ShouldBe(true);
        }
    }
}
