﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Versioning;

    using Shouldly;

    public sealed class DependencyTests
    {
        [Input("AutoFixture")]
        [Input("AutoFixture.Idioms")]
        [Input("Media.Specifications")]
        [Input("Media.Domain.Tests")]
        [Input("Shouldly")]
        [Input("FixieSpec")]
        [Input("Fixie")]
        public void ShouldNotReference(string assemblyName)
        {
            var references = typeof(DeviceId).Assembly.GetReferencedAssemblies();

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
