// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>


namespace Media.Domain.Tests.Recording
{
    using System;

    using Shouldly;
    using Domain.Recording;

    public class VideoRecordingTests
    {
        public void ShouldFailWhenConstructedUsingNullVideoSourceDevice()
        {
            Action act = () => new VideoRecording(null);

            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
