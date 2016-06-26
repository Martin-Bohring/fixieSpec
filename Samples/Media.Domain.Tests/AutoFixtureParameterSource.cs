// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Fixie;
    using Ploeh.AutoFixture;
    using Fixture = Ploeh.AutoFixture.Fixture;

    using Customizations;

    sealed class AutoFixtureParameterSource : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            IFixture fixture = new Fixture();

            CustomizeAutoFixture(fixture);

            yield return GetParameterValues(method.GetParameters(), fixture);
        }

        object[] GetParameterValues(ParameterInfo[] parameters, IFixture fixture)
        {
            return parameters
                .Select(p => fixture.Resolve(p.ParameterType))
                .ToArray();
        }
        
        static void CustomizeAutoFixture(IFixture fixture)
        {
            fixture.Customize(new MediaDomainCustomization());
        }
    }
}