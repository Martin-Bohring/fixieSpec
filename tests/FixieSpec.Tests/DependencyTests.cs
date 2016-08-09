// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Versioning;

    using Shouldly;

    public sealed class DependencyTests
    {
        [Input("Ploeh.AutoFixture")]
        [Input("Ploeh.AutoFixture.Idioms")]
        [Input("Shouldly")]
        [Input("FixieSpec.Tests")]
        [Input("FixieSpec.Specifications")]
        public void ShouldNotReference(string assemblyName)
        {
            var references = typeof(FixieSpecConvention).Assembly.GetReferencedAssemblies();

            references.ShouldNotContain(reference => reference.Name == assemblyName);
        }

        [Input("FixieSpec.Specifications")]
        public void UnitTestShouldNotReference(string assemblyName)
        {
            var references = GetType().Assembly.GetReferencedAssemblies();

            references.ShouldNotContain(reference => reference.Name == assemblyName);
        }

        public void ShouldAtLeastRequireNet45()
        {
            var quirksAreEnabled = Uri.EscapeDataString("'") == "'";

            quirksAreEnabled.ShouldBeFalse();

            var targetFramework =
                Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(TargetFrameworkAttribute), true)
                    .Cast<TargetFrameworkAttribute>()
                    .Single()
                    .FrameworkName;

            quirksAreEnabled.ShouldBe(!targetFramework.Contains("4.5"));
        }
    }
}
