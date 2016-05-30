// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public sealed class VideoCameraTests : DeviceBaseTests<VideoCamera>
    {
        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId()
        {
            var videoCamera = new VideoCamera();

            videoCamera.DeviceId.ShouldNotBeNull();
        }

        public void ShouldBeRecordingWhenRecordingIsStarted()
        {
            var videoCamera = CreateDevice(new DeviceId());

            videoCamera.StartRecording();

            videoCamera.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void ShouldFailToStartRecordingWhenAlreadyRecording()
        {
            var videoCamera = CreateDevice(new DeviceId());
            videoCamera.StartRecording();

            videoCamera.StartRecording().ShouldBeFalse();
        }

        protected override VideoCamera CreateDevice(DeviceId id)
        {
            return new VideoCamera(id);
        }
    }
}
