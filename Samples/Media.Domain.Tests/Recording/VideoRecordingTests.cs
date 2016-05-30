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
        public void ShouldFailToStartRecordingUsingNullDevice(
            VideoRecording videoRecording)
        {
            Action act = () => videoRecording.StartRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldStartWhenSourceDeviceIsAvailable(
            VideoRecording videoRecording,
            VideoCamera camera
            )
        {
            videoRecording.StartRecording(camera).ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful(
            VideoRecording videoRecording,
            VideoCamera camera)
        {
            videoRecording.StartRecording(camera);

            videoRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldNotStartWhenSourceDeviceIsNotAvailable(
            VideoRecording videoRecording,
            VideoCamera camera)
        {
            camera.StartRecording();

            videoRecording.StartRecording(camera).ShouldBeFalse();
        }
    }
}
