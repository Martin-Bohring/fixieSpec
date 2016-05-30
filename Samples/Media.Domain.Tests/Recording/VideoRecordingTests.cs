// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using System;

    using Shouldly;

    public class VideoRecordingTests
    {
        public void ShouldFailWhenConstructedUsingNullVideoSourceDevice()
        {
            Action act = () => new VideoRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldStartWhenSourceDeviceIsAvailable()
        {
            var camera = new VideoCamera(new DeviceId());

            var videoRecording = new VideoRecording(camera);

            videoRecording.StartRecording().ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful()
        {
            var camera = new VideoCamera(new DeviceId());
            var videoRecording = new VideoRecording(camera);

            videoRecording.StartRecording();

            videoRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldNotStartWhenSourceDeviceIsNotAvailable()
        {
            var camera = new VideoCamera(new DeviceId());
            camera.StartRecording();

            var videoRecording = new VideoRecording(camera);

            videoRecording.StartRecording().ShouldBeFalse();
        }
    }
}
