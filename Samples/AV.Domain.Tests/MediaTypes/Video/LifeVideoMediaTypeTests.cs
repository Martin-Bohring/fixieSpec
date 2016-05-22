// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Video.Tests
{
    using Shouldly;

    public sealed class LifeVideoTests
    {
        readonly LifeVideoMediaType testee = new LifeVideoMediaType();

        public void SutIsVideo()
        {
            testee.ShouldBeAssignableTo<VideoTypeType>();
        }

        public void ShouldBeLife()
        {
            testee.IsLive.ShouldBe(true);
        }
    }
}
