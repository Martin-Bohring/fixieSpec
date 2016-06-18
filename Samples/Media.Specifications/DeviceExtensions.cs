// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Shouldly;

    using Domain;
    using Domain.Recording;

    public static class DeviceExtensions
    {
        public static void ShouldBeRecording(this Device self, IMediaRecording recording)
        {
            self.IsInRole(new RoleInActivity(DeviceRole.Recording, recording.ActivityId)).ShouldBeTrue();
        }

        public static void ShouldNotBeRecording(this Device self, IMediaRecording recording)
        {
            self.IsInRole(new RoleInActivity(DeviceRole.Recording, recording.ActivityId)).ShouldBeFalse();
        }
    }
}
