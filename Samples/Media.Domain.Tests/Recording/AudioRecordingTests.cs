// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using System;

    using Shouldly;
    using Domain.Tests;

    public class AudioRecordingTests
    {
        public void ShouldFailWhenConstructedUsingNullDevice()
        {
            Action act = () => new AudioRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Input(DeviceRole.Idle, true)]
        [Input(DeviceRole.Background, false)]
        public void ShouldOnlyStartWhenSourceDeviceIsAvailable(
            DeviceRole sourceDeviceRole,
            bool shouldStart)
        {
            var microphone = new Microphone(new DeviceId());
            microphone.SelectFor(sourceDeviceRole);

            var mediaRecording = new AudioRecording(microphone);

            mediaRecording.StartRecording().ShouldBe(shouldStart);
        }

        public void ShouldBeRecordingWhenStartedSuccessful()
        {
            var microphone = new Microphone(new DeviceId());
            var mediaRecording = new AudioRecording(microphone);

            mediaRecording.StartRecording();

            mediaRecording.IsRecording().ShouldBeTrue();
        }
    }
}
