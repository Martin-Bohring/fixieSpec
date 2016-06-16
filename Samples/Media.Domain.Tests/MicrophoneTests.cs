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

        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typeof(Microphone).GetMethods());
        }

        public void ShouldInitializeReadOnlyPropertiesByConstructor()
        {
            var fixture = new Fixture();

            var intializeReadOnlyPropertiesAssertion = new ConstructorInitializedMemberAssertion(fixture);

            intializeReadOnlyPropertiesAssertion.Verify(typeof(Microphone).GetProperties());
        }

        public void ShouldBeAvailableWhenConstructed(Microphone microphone)
        {
            microphone.IsAvailable().ShouldBeTrue();
        }

        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId(Microphone microphone)
        {
            microphone.Id.ShouldNotBeNull();
        }

        public void ShouldBeRecordingWhenUsedForAudioRecording(
            Microphone microphone,
            ActivityId audioRecording)
        {
            microphone.UseForAudioRecording(audioRecording);

            microphone.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void CannotUseForAudioRecordingWhenAlreadyRecording(
            Microphone microphone,
            ActivityId previousAudioRecording,
            ActivityId newAudioRecording)
        {
            microphone.UseForAudioRecording(previousAudioRecording);

            microphone.UseForAudioRecording(newAudioRecording).ShouldBeFalse();
        }
    }
}
