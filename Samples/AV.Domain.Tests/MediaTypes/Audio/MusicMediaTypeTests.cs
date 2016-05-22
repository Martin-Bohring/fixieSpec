// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Audio.Tests
{
    using Shouldly;

    public sealed class MusicMediaTypeTests
    {
        readonly MusicMediaType testee = new MusicMediaType();

        public void SutIsAudio()
        {
            testee.ShouldBeAssignableTo<AudioMediaType>();
        }

        public void ShouldNotBeLife()
        {
            testee.IsLive.ShouldBe(false);
        }
    }
}
