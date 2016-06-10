// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using FixieSpec;

    using Media.Specifications;

    using Domain;
    using Domain.Recording;

    public sealed class VideoRecordingNotPossibleWithoutCameraAvailable
    {
        readonly VideoCamera camera = new VideoCamera();

        readonly VideoRecording videoRecording = new VideoRecording();

        public void Given_a_camera_is_not_available()
        {
            camera.UseForVideoRecording();
        }

        public void When_a_video_recording_is_started()
        {
            videoRecording.StartRecording(camera);
        }

        public void Then_the_video_recording_should_be_recording()
        {
            videoRecording.ShouldNotBeRecording();
        }

        [Inconclusive("Find a different way to verify if the camera is recording")]
        public void And_then_the_selected_camera_is_not_used_for_recording()
        {
            camera.ShouldBeRecording();
        }
    }
}
