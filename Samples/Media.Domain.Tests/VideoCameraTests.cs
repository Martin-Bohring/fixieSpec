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

        [Input(DeviceRole.Idle, DeviceRole.Recording, true)]
        [Input(DeviceRole.Background, DeviceRole.Recording, false)]
        [Input(DeviceRole.Playback, DeviceRole.Recording, false)]
        [Input(DeviceRole.Recording, DeviceRole.Recording, false)]
        [Input(DeviceRole.Communication, DeviceRole.Recording, false)]
        [Input(DeviceRole.Prompt, DeviceRole.Recording, false)]
        [Input(DeviceRole.Alert, DeviceRole.Recording, false)]
        public void ShouldOnlyAssumeRoleWhenAvailable(
            DeviceRole previousRole,
            DeviceRole roleToAssume,
            bool shouldAssumeRole)
        {
            var videoCamera = CreateDevice(new DeviceId());
            videoCamera.SelectFor(previousRole);

            var hasAssumedRole = videoCamera.SelectFor(roleToAssume);

            hasAssumedRole.ShouldBe(shouldAssumeRole);
        }

        protected override VideoCamera CreateDevice(DeviceId id)
        {
            return new VideoCamera(id);
        }
    }
}
