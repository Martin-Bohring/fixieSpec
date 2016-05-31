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
    using Ploeh.AutoFixture.Kernel;
    using Fixture = Ploeh.AutoFixture.Fixture;

    public class AutoFixtureParameterSource : ParameterSource
    {
        /// <inheritdoc/>
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            IFixture fixture = new Fixture();

            yield return GetParameterValues(method.GetParameters(), fixture);
        }

        object[] GetParameterValues(ParameterInfo[] parameters, IFixture fixture)
        {
            return parameters
                .Select(p => new SpecimenContext(fixture).Resolve(p.ParameterType))
                .ToArray();
        }
    }
}