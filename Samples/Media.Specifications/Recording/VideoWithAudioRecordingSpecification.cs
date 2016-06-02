// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specification
{
    using Shouldly;

    using Domain;
    using Domain.Recording;

    public sealed class VideoWithAudioRecordingSpecification
    {
        readonly Microphone microphone = new Microphone();
        readonly VideoCamera camera = new VideoCamera();

        readonly VideoRecording videoRecording = new VideoRecording();

        public void Given_a_camera_is_available()
        {
            camera.MakeAvailable();
        }

        public void And_given_a_microphone_is_available()
        {
            microphone.MakeAvailable();
        }

        public void When_the_video_recording_is_started()
        {
            videoRecording.StartRecording(camera, microphone);
        }

        public void Then_the_video_recording_should_be_recording()
        {
            videoRecording.IsRecording().ShouldBeTrue();
        }

        public void And_Then_the_selected_camera_is_used_for_recording()
        {
            camera.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        public void And_then_the_selected_microphone_is_used_for_recording()
        {
            microphone.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }

        public void And_then_the_selected_camera_is_not_available_anymore()
        {
            camera.IsAvailable().ShouldBeFalse();
        }

        public void And_then_the_selected_microphone_is_not_available_anymore()
        {
            microphone.IsAvailable().ShouldBeFalse();
        }
    }
}
