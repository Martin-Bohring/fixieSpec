// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;

    static class TestExtensions
    {
        public static IEnumerable<Type> ConcreteTypesInAssembly(this Assembly self)
        {
            return self
                .GetExportedTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface);
        }

        public static object Resolve(this IFixture fixture, Type typeToResolve)
        {
            return new SpecimenContext(fixture).Resolve(typeToResolve);
        }
    }
}