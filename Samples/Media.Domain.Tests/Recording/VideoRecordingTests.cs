// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using System;

    using Shouldly;
    using Domain.Tests;

    public class VideoRecordingTests
    {
        public void ShouldFailWhenConstructedUsingNullVideoSourceDevice()
        {
            Action act = () => new VideoRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Input(DeviceRole.Idle, true)]
        [Input(DeviceRole.Background, false)]
        public void ShouldOnlyStartWhenSourceDeviceIsAvailable(
            DeviceRole sourceDeviceRole,
            bool shouldStart)
        {
            var camera = new VideoCamera(new DeviceId());
            camera.SelectFor(sourceDeviceRole);

            var videoRecording = new VideoRecording(camera);

            videoRecording.StartRecording().ShouldBe(shouldStart);
        }

        public void ShouldBeRecordingWhenStartedSuccessful()
        {
            var camera = new VideoCamera(new DeviceId());
            var videoRecording = new VideoRecording(camera);

            videoRecording.StartRecording();

            videoRecording.IsRecording().ShouldBeTrue();
        }
    }
}
