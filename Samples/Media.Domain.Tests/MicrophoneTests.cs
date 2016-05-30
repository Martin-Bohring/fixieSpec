// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public sealed class MicrophoneTests : DeviceBaseTests<Microphone>
    {
        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId()
        {
            var microphone = new Microphone();

            microphone.DeviceId.ShouldNotBeNull();
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
            var microphone = CreateDevice(new DeviceId());
            microphone.SelectFor(previousRole);

            var hasAssumedRole = microphone.SelectFor(roleToAssume);

            hasAssumedRole.ShouldBe(shouldAssumeRole);
        }

        public void ShouldBeRecordingWhenRecordingIsStarted()
        {
            var microphone = CreateDevice(new DeviceId());

            microphone.StartRecording();

            microphone.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        protected override Microphone CreateDevice(DeviceId id)
        {
            return new Microphone(id);
        }
    }
}
