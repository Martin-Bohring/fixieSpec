// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using System;

    using Shouldly;

    public class AudioRecordingTests
    {
        public void ShouldFailToStartRecordingUsingNullDevice(
            AudioRecording audioRecording)
        {
            Action act = () => audioRecording.StartRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldStartWhenSourceDeviceIsAvailable(
            AudioRecording audioRecording,
            Microphone microphone)
        {
            audioRecording.StartRecording(microphone).ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful(
            AudioRecording audioRecording,
            Microphone microphone)
        {
            audioRecording.StartRecording(microphone);

            audioRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldNotStartWhenSourceDeviceIsNotAvailable(
            AudioRecording audioRecording,
            Microphone microphone)
        {
            microphone.UseForAudioRecording();

            audioRecording.StartRecording(microphone).ShouldBeFalse();
        }
    }
}
