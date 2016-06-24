// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests.Customizations
{
    using System;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;

    sealed class DeviceCustomization : PickRandomItemFromFixedSequenceCustomization<Type>
    {
        public DeviceCustomization() : base (new Type[] {typeof(Microphone), typeof(VideoCamera) })
        {
        }

        public override void Customize(IFixture fixture)
        {
            fixture.Register(() => CreateDeviceOfRandomType(fixture));
        }

        public Device CreateDeviceOfRandomType(IFixture fixture)
        {
            return (Device)new SpecimenContext(fixture)
                .Resolve(PickRandomIngredientFromSequence());
        }
    }
}
