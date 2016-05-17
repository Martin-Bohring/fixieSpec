// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.MediaTypes.Tests
{
    using Shouldly;

    public sealed class VoiceTests
    {
        readonly Voice testee = new Voice();

        public void SutIsAudio()
        {
            testee.ShouldBeAssignableTo<Audio>();
        }

        public void ShouldBeLife()
        {
            testee.IsLive.ShouldBe(true);
        }
    }
}
