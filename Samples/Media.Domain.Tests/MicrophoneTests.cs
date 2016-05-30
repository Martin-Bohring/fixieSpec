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

        public void ShouldBeRecordingWhenRecordingIsStarted()
        {
            var microphone = CreateDevice(new DeviceId());

            microphone.StartRecording();

            microphone.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void ShouldFailToStartRecordingWhenAlreadyRecording()
        {
            var microphone = CreateDevice(new DeviceId());
            microphone.StartRecording();

            microphone.StartRecording().ShouldBeFalse();
        }

        protected override Microphone CreateDevice(DeviceId id)
        {
            return new Microphone(id);
        }
    }
}
