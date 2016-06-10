// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{

    using Shouldly;
    using Ploeh.AutoFixture.Idioms;
    using Ploeh.AutoFixture;

    public sealed class MicrophoneTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();

            var guardsConstructorsAssertion = new GuardClauseAssertion(fixture);

            guardsConstructorsAssertion.Verify(typeof(Microphone).GetConstructors());
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
