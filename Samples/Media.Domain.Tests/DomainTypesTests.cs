// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public sealed class DomainTypesTests
    {
        public void ShouldGuardMethodParameters()
        {
            var fixture = new Fixture();

            fixture.Register<IAudioRecordingSource>(() => new Microphone());
            fixture.Register<IVideoRecordingSource>(() => new VideoCamera());

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(DomainTypes());
        }

        public void ShouldInitializeReadOnlyPropertiesByConstructor()
        {
            var fixture = new Fixture();

            var intializeReadOnlyPropertiesAssertion = new ConstructorInitializedMemberAssertion(fixture);

            var typesToExclude = new[]
            {
                typeof(ActivityId), // Does not expose an Id property and doing so is not needed
                typeof(DeviceId) // Does not expose an Id property and doing so is not needed
            };

            intializeReadOnlyPropertiesAssertion.Verify
                (DomainTypes()
                .Except(typesToExclude));
        }

        static IEnumerable<Type> DomainTypes()
        {
            var typesToExclude = new[]
            {
                typeof(DeviceRole), // AutoFixture pukes on enum types
                typeof(DeviceState) // AutoFixture pukes on enum types
            };

            return typeof(Device).Assembly.GetExportedTypes()
                .Where(type => !type.IsAbstract)
                .Except(typesToExclude);
        }
    }
}