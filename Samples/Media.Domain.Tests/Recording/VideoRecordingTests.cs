// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{

    using Domain;

    using Shouldly;
    using Ploeh.AutoFixture.Idioms;
    using Ploeh.AutoFixture;

    public class VideoRecordingTests
    {
        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();
            fixture.Register<IAudioRecordingSource>(() => new Microphone());
            fixture.Register<IVideoRecordingSource>(() => new VideoCamera());

            var guardsConstructorsAssertion = new GuardClauseAssertion(fixture);

            guardsConstructorsAssertion.Verify(typeof(VideoRecording).GetMethods());
        }

        public void ShouldStartWhenVideoRecordingSourcesAreAvailable(
            VideoRecording videoRecording,
            VideoCamera camera,
            Microphone microphone)
        {
            videoRecording.StartRecording(camera, microphone).ShouldBeTrue();
        }

        public void ShouldStartWhenVideoRecordingSourcesAreAvailable(
            VideoRecording videoRecording,
            VideoCamera camera)
        {
            videoRecording.StartRecording(camera).ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful(
            VideoRecording videoRecording,
            VideoCamera camera,
            Microphone microphone)
        {
            videoRecording.StartRecording(camera, microphone);

            videoRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldBeRecordingWhenStartedSuccessful(
            VideoRecording videoRecording,
            VideoCamera camera)
        {
            videoRecording.StartRecording(camera);

            videoRecording.IsRecording().ShouldBeTrue();
        }

        public void ShouldNotStartWhenVideoRecordingSourceIsNotAvailable(
            VideoRecording videoRecording,
            VideoCamera camera,
            Microphone microphone)
        {
            camera.UseForVideoRecording();

            videoRecording.StartRecording(camera, microphone).ShouldBeFalse();
        }

        public void ShouldNotStartWhenVideoRecordingSourceIsNotAvailable(
            VideoRecording videoRecording,
            VideoCamera camera)
        {
            camera.UseForVideoRecording();

            videoRecording.StartRecording(camera).ShouldBeFalse();
        }
    }
}
