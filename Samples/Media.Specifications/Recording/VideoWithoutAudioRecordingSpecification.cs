﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications.Recording
{
    using FixieSpec;
    using Shouldly;

    using Domain;
    using Domain.Recording;

    public sealed class VideoWithoutAudioRecordingSpecification
    {
        readonly VideoCamera camera = new VideoCamera();

        readonly VideoRecording videoRecording = new VideoRecording();

        public void Given_a_camera_is_available()
        {
            camera.MakeAvailable();
        }

        [Inconclusive]
        public void When_a_video_recording_is_started()
        {
        }

        [Inconclusive]
        public void Then_the_video_recording_should_be_recording()
        {
            videoRecording.IsRecording().ShouldBeTrue();
        }

        [Inconclusive]
        public void And_Then_the_selected_camera_is_used_for_recording()
        {
            camera.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        [Inconclusive]
        public void And_then_the_selected_camera_is_not_available_anymore()
        {
            camera.IsAvailable().ShouldBeFalse();
        }
    }
}
