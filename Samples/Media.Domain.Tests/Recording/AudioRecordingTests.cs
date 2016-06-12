// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public class AudioRecordingTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();

            var guardConstructorParametersAssertion = new GuardClauseAssertion(fixture);

            guardConstructorParametersAssertion.Verify(typeof(AudioRecording).GetConstructors());
        }

        public void ShouldInitializeReadOnlyPropertiesByConstructor()
        {
            var fixture = new Fixture();

            var intializeReadOnlyPropertiesAssertion = new ConstructorInitializedMemberAssertion(fixture);

            intializeReadOnlyPropertiesAssertion.Verify(typeof(AudioRecording).GetProperties());
        }

        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();
            fixture.Register<IAudioRecordingSource>(() => new Microphone());

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typeof(AudioRecording).GetMethods());
        }
    }
}
