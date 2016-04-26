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

    using Fixie;
    using Fixie.Execution;
    using Fixie.Internal;
    using Shouldly;

    /// <summary>
    /// Test helper extension class taken from
    /// https://github.com/fixie/fixie/blob/master/src/Fixie.Tests/TestExtensions.cs.
    /// </summary>
    public static class TestExtensions
    {
        const BindingFlags InstanceMethods = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        public static MethodInfo GetInstanceMethod(this Type type, string methodName)
        {
            return type.GetMethod(methodName, InstanceMethods);
        }

        public static AssemblyResult Run(this Type sampleTestClass, Listener listener, Convention convention)
        {
            if (sampleTestClass == null)
            {
                throw new ArgumentNullException(nameof(sampleTestClass));
            }

            if (listener == null)
            {
                throw new ArgumentNullException(nameof(listener));
            }

            if (convention == null)
            {
                throw new ArgumentNullException(nameof(convention));
            }

            return new Runner(listener).RunTypes(sampleTestClass.Assembly, convention, sampleTestClass);
        }

        public static IEnumerable<string> Lines(this RedirectedConsole console)
        {
            if (console == null)
            {
                throw new ArgumentNullException(nameof(console));
            }

            return console.Output.Lines();
        }

        public static IEnumerable<string> Lines(this string multiline)
        {
            if (multiline == null)
            {
                throw new ArgumentNullException(nameof(multiline));
            }

            var lines = multiline.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            while (lines.Count > 0 && lines[lines.Count - 1] == string.Empty)
            {
                lines.RemoveAt(lines.Count - 1);
            }

            return lines;
        }

        public static void ShouldEqual<T>(this IEnumerable<T> actual, params T[] expected)
        {
            actual.ToArray().ShouldBe(expected);
        }
    }
}
