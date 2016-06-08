// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Shouldly;

    using Domain;

    public static class DeviceExtensions
    {
        public static void ShouldBeRecording(this Device self)
        {
            self.IsInRole(DeviceRole.Recording).ShouldBeTrue();
        }
    }
}
