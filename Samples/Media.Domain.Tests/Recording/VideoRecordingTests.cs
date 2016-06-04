// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Recording.Tests
{
    using System;

    using Shouldly;

    public class VideoRecordingTests
    {
        public void ShouldFailToStartRecordingUsingNullVideoRecordingSource(
            VideoRecording videoRecording,
            Microphone microphone)
        {
            Action act = () => videoRecording.StartRecording(null, microphone);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldFailToStartRecordingUsingNullVideoRecordingSource(
            VideoRecording videoRecording)
        {
            Action act = () => videoRecording.StartRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldFailToStartRecordingUsingNullAudioRecordingSource(
            VideoRecording videoRecording,
            VideoCamera camera)
        {
            Action act = () => videoRecording.StartRecording(camera, null);

            act.ShouldThrow<ArgumentNullException>();
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
