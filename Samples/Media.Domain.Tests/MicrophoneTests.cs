// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;
    using Shouldly;

    public sealed class MicrophoneTests
    {
        public void ShouldFailWhenConstructedUsingNullDeviceId()
        {
            Action act = () => new Microphone(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldBeAvailableWhenConstructed(Microphone microphone)
        {
            microphone.IsAvailable().ShouldBeTrue();
        }

        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId(Microphone microphone)
        {
            microphone.DeviceId.ShouldNotBeNull();
        }

        public void ShouldBeRecordingWhenUsedForAudioRecording(Microphone microphone)
        {
            microphone.UseForAudioRecording();

            microphone.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void CannotUseForAudioRecordingWhenAlreadyRecording(Microphone microphone)
        {
            microphone.UseForAudioRecording();

            microphone.UseForAudioRecording().ShouldBeFalse();
        }
    }
}
