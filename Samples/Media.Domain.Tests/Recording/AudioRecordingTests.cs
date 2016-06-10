// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{

    using Shouldly;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public class AudioRecordingTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typeof(AudioRecording).GetConstructors());
        }

        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();
            fixture.Register<IAudioRecordingSource>(() => new Microphone());

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typeof(AudioRecording).GetMethods());
        }

        public void ShouldStartWhenSourceDeviceIsAvailable(
            AudioRecording audioRecording,
            Microphone microphone)
        {
            audioRecording.StartRecording(microphone).ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful(
            AudioRecording audioRecording,
            Microphone microphone)
        {
            audioRecording.StartRecording(microphone);

            audioRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldNotStartWhenSourceDeviceIsNotAvailable(
            AudioRecording audioRecording,
            Microphone microphone)
        {
            microphone.UseForAudioRecording();

            audioRecording.StartRecording(microphone).ShouldBeFalse();
        }
    }
}
