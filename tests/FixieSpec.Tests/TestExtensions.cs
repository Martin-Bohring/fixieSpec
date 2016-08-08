// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Test helper extension class taken from
    /// https://github.com/fixie/fixie/blob/master/src/Fixie.Tests/TestExtensions.cs.
    /// </summary>
    static class TestExtensions
    {
        const BindingFlags InstanceMethods = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        public static MethodInfo GetInstanceMethod(this Type type, string methodName)
        {
            return type.GetMethod(methodName, InstanceMethods);
        }
    }
}
