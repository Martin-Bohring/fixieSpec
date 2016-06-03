// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Shouldly;

    using Domain.Recording;

    static class MediaRecordingExtensions
    {
        public static void ShouldBeRecording(this IMediaRecording self)
        {
            self.IsRecording().ShouldBeTrue();
        }

        public static void ShouldNotBeRecording(this IMediaRecording self)
        {
            self.IsRecording().ShouldBeFalse();
        }
    }
}
