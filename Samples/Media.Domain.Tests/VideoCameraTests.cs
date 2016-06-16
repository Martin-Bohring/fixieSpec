// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;
    using Ploeh.AutoFixture.Idioms;
    using Ploeh.AutoFixture;

    public sealed class VideoCameraTests
    {
        public void ShouldGuardConstructorParameters()
        {
            var fixture = new Fixture();

            var guardsConstructorsAssertion = new GuardClauseAssertion(fixture);

            guardsConstructorsAssertion.Verify(typeof(VideoCamera).GetConstructors());
        }

        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typeof(VideoCamera).GetMethods());
        }

        public void ShouldInitializeReadOnlyPropertiesByConstructor()
        {
            var fixture = new Fixture();

            var intializeReadOnlyPropertiesAssertion = new ConstructorInitializedMemberAssertion(fixture);

            intializeReadOnlyPropertiesAssertion.Verify(typeof(VideoCamera).GetProperties());
        }

        public void ShouldBeAvailableWhenConstructed(VideoCamera videoCamera)
        {
            videoCamera.IsAvailable().ShouldBeTrue();
        }

        public void ShouldGenerateDeviceIdWhenConstructedWithoutDeviceId(VideoCamera videoCamera)
        {
            videoCamera.Id.ShouldNotBeNull();
        }

        public void ShouldBeRecordingWhenUsedForVideoRecording(
            VideoCamera videoCamera,
            ActivityId videoRecording)
        {
            videoCamera.UseForVideoRecording(videoRecording);

            videoCamera.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        void CannotUseForVideoRecordingWhenAlreadyRecording(
            VideoCamera videoCamera,
            ActivityId previousVideoRecording,
            ActivityId newVideoRecording)
        {
            videoCamera.UseForVideoRecording(previousVideoRecording);

            videoCamera.UseForVideoRecording(newVideoRecording).ShouldBeFalse();
        }
    }
}
