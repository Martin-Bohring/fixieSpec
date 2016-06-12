// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using Domain;
    using Ploeh.AutoFixture.Idioms;
    using Ploeh.AutoFixture;

    public class VideoRecordingTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();
            var guardConstructorParametersAssertion = new GuardClauseAssertion(fixture);

            guardConstructorParametersAssertion.Verify(typeof(VideoRecording).GetConstructors());
        }

        public void ShouldInitializeReadOnlyPropertiesByConstructor()
        {
            var fixture = new Fixture();

            var intializeReadOnlyPropertiesAssertion = new ConstructorInitializedMemberAssertion(fixture);

            intializeReadOnlyPropertiesAssertion.Verify(typeof(VideoRecording).GetProperties());
        }

        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();
            fixture.Register<IAudioRecordingSource>(() => new Microphone());
            fixture.Register<IVideoRecordingSource>(() => new VideoCamera());

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typeof(VideoRecording).GetMethods());
        }
    }
}
