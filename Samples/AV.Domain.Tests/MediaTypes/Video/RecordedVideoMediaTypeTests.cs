﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Video.Tests
{
    using Shouldly;

    public sealed class RecordedVideoTests
    {
        readonly RecordedVideoMediaType testee = new RecordedVideoMediaType();

        public void SutIsVideo()
        {
            testee.ShouldBeAssignableTo<VideoTypeType>();
        }

        public void ShouldNotBeLife()
        {
            testee.IsLive.ShouldBe(false);
        }
    }
}
