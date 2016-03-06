// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using Shouldly;

    public sealed class DependencyTests
    {
        [Input("FakeItEasy")]
        [Input("Ploeh.AutoFixture")]
        [Input("Ploeh.AutoFixture.AutoFakeItEasy")]
        [Input("Shouldly")]
        public void FixieSpecSHouldNotReference(string assemblyName)
        {
            var references = typeof(FixieSpecConvention).Assembly.GetReferencedAssemblies();

            references.ShouldNotContain(reference => reference.Name == assemblyName);
        }
    }
}
