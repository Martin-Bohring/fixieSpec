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

    static class TestExtensions
    {
        public static IEnumerable<Type> CreatableTypesInAssembly(this Assembly self)
        {
            return self
                .GetExportedTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface);
        }
    }
}
