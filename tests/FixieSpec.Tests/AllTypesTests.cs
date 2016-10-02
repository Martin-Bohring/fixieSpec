// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Idioms;

    public sealed class AllTypesTests
    {
        public void AllTypesShouldGuardMethodParameters()
        {
            var fixture = new Fixture();
            fixture.Register<MethodBase>(() => typeof(object).GetMethod("ToString"));
            fixture.Register(() => typeof(object).GetMethod("ToString"));

            var guardMethodParametersAssertion = new GuardClauseAssertion(fixture);

            var allTypes = AllTypes();

            guardMethodParametersAssertion.Verify(allTypes);
        }

        static IEnumerable<Type> AllTypes()
        {
            var typesToExclude = new[]
            {
                // AutoFixture pukes on enum types
                typeof(StepRoleInScenario),

                // Handles null values differently
                typeof(DeclarationOrderComparer),

                // Attributes are constructed during compile time
                typeof(InconclusiveAttribute)
            };

            return typeof(FixieSpecConvention).Assembly
                .GetExportedTypes()
                .Except(typesToExclude);
        }
    }
}
