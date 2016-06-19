// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public sealed class RoleInActivityTests
    {
        public void ShouldCreateRecordingRole(ActivityId activity)
        {
            var recordingRoleInActivity = RoleInActivity.Recording(activity);

            recordingRoleInActivity.Activity.ShouldBe(activity);
            recordingRoleInActivity.Role.ShouldBe(DeviceRole.Recording);
        }

        public void ShouldCreateNoneRole()
        {
            var noRoleInActivity = RoleInActivity.None();

            noRoleInActivity.Activity.ShouldBe(ActivityId.Empty);
            noRoleInActivity.Role.ShouldBe(DeviceRole.Idle);
        }
    }
}
