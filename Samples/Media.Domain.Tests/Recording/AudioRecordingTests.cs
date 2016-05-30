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
        public void ShouldFailWhenConstructedUsingNullDevice()
        {
            Action act = () => new AudioRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldStartWhenSourceDeviceIsAvailable()
        {
            var microphone = new Microphone(new DeviceId());

            var audioRecording = new AudioRecording(microphone);

            audioRecording.StartRecording().ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful()
        {
            var microphone = new Microphone(new DeviceId());
            var audioRecording = new AudioRecording(microphone);

            audioRecording.StartRecording();

            audioRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldNotStartWhenSourceDeviceIsNotAvailable()
        {
            var microphone = new Microphone(new DeviceId());
            microphone.StartRecording();

            var audioRecording = new AudioRecording(microphone);

            audioRecording.StartRecording().ShouldBeFalse();
        }
    }
}
