// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>


namespace Media.Domain.Tests
{
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

            var typesToExclude = new[]
            {
                typeof(DeviceRole),
                typeof(DeviceState)
            };

            var typesToVerify = typeof(Device).Assembly.GetExportedTypes()
                .Where(type => !type.IsAbstract)
                .Except(typesToExclude);

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            guardMethodParametersAssertion.Verify(typesToVerify);
        }
    }
}
