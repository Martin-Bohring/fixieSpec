// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Tests
{
    using Shouldly;

    public sealed class LifeVideoTests
    {
        readonly LifeVideo testee = new LifeVideo();

        public void SutIsVideo()
        {
            testee.ShouldBeAssignableTo<Video>();
        }

        public void ShouldBeLife()
        {
            testee.IsLive.ShouldBe(true);
        }
    }
}
