﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Shouldly;

    using Domain;
    using Domain.Recording;

    using Media.Specifications;

    public sealed class VideoRecordingSucceedsWithCameraOnly
    {
        readonly VideoCamera camera;

        readonly VideoRecording videoRecording;

        public VideoRecordingSucceedsWithCameraOnly(
            VideoRecording aVideoRecording,
            VideoCamera aCamera)
        {
            videoRecording = aVideoRecording;
            camera = aCamera;
        }

        public void Given_a_camera_is_available()
        {
            camera.MakeAvailable();
        }

        public void When_a_video_recording_is_started()
        {
            videoRecording.StartRecording(camera);
        }

        public void Then_the_video_recording_should_be_recording()
        {
            videoRecording.ShouldBeRecording();
        }

        public void And_then_the_selected_camera_is_used_for_recording()
        {
            camera.ShouldBeRecording(videoRecording);
        }

        public void And_then_the_selected_camera_is_not_available_anymore()
        {
            camera.IsAvailable().ShouldBeFalse();
        }
    }
}
