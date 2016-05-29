// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using Shouldly;

    public class MicrophoneTests
    {
        [Input(DeviceRole.Idle, DeviceRole.Recording, true)]
        [Input(DeviceRole.Background, DeviceRole.Recording, false)]
        [Input(DeviceRole.Playback, DeviceRole.Recording, false)]
        [Input(DeviceRole.Recording, DeviceRole.Recording, false)]
        [Input(DeviceRole.Communication, DeviceRole.Recording, false)]
        [Input(DeviceRole.Prompt, DeviceRole.Recording, false)]
        [Input(DeviceRole.Alert, DeviceRole.Recording, false)]
        public void ShouldOnlyAssumeRoleWhenAvailable(
            DeviceRole previousRole,
            DeviceRole roleToAssume,
            bool shouldAssumeRole)
        {
            var device = new Microphone(new DeviceId());
            device.SelectFor(previousRole);

            var assumedRole = device.SelectFor(roleToAssume);

            assumedRole.ShouldBe(shouldAssumeRole);
        }
    }
}
