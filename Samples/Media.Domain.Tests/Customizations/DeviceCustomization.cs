﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests.Customizations
{

    using Ploeh.AutoFixture;

    class DeviceCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<Device>(() => new Microphone());
        }
    }
}
