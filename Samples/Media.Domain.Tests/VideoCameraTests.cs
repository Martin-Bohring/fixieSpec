// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;
    using Shouldly;

    public sealed class VideoCameraTests
    {
        public void ShouldFailWhenConstructedUsingNullDeviceId()
        {
            Action act = () => new VideoCamera(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldBeAvailableWhenConstructed(VideoCamera videoCamera)
        {
            videoCamera.IsAvailable().ShouldBeTrue();
        }

        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId(VideoCamera videoCamera)
        {
            videoCamera.DeviceId.ShouldNotBeNull();
        }

        public void ShouldBeRecordingWhenUsedForVideoRecording(VideoCamera videoCamera)
        {
            videoCamera.UseForVideoRecording();

            videoCamera.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void CannotUseForVideoRecordingWhenAlreadyRecording(VideoCamera videoCamera)
        {
            videoCamera.UseForVideoRecording();

            videoCamera.UseForVideoRecording().ShouldBeFalse();
        }
    }
}
