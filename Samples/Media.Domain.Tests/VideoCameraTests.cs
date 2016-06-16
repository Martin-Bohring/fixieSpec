// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public sealed class VideoCameraTests
    {
        public void ShouldBeAvailableWhenConstructed(VideoCamera videoCamera)
        {
            videoCamera.IsAvailable().ShouldBeTrue();
        }

        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId(VideoCamera videoCamera)
        {
            videoCamera.Id.ShouldNotBeNull();
        }

        public void ShouldBeRecordingWhenUsedForVideoRecording(
            VideoCamera videoCamera,
            ActivityId videoRecording)
        {
            videoCamera.UseForVideoRecording(videoRecording);

            videoCamera.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void CannotUseForVideoRecordingWhenAlreadyRecording(
            VideoCamera videoCamera,
            ActivityId previousVideoRecording,
            ActivityId newVideoRecording)
        {
            videoCamera.UseForVideoRecording(previousVideoRecording);

            videoCamera.UseForVideoRecording(newVideoRecording).ShouldBeFalse();
        }
    }
}
