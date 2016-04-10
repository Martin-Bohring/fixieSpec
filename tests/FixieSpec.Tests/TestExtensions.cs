// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fixie;
    using Fixie.Execution;
    using Fixie.Internal;
    using Shouldly;

    /// <summary>
    /// Test helper extension class taken from
    /// https://github.com/fixie/fixie/blob/master/src/Fixie.Tests/TestExtensions.cs and stripped
    /// down to what is needed for the https://github.com/Martin-Bohring/fixieSpec tests.
    /// </summary>
    /// <remarks>
    /// We are taking a bet here and depend on the <see cref="Runner"/> class which is internal to http://fixie.github.io/.
    ///
    /// On the other hand I have found no good way of testing the <see cref="FixieSpecConvention"/>
    /// without using the runner. Also http://fixie.github.io/ itself is using the runner in several
    /// of its runners in a public way.
    /// </remarks>
    public static class TestExtensions
    {
        /// <summary>
        /// Runs the tests of the class given by <paramref name="sampleTestClass"/> identified by the
        /// convention given by <paramref name="convention"/>
        /// </summary>
        /// <param name="sampleTestClass">
        /// The type of the test class containing the tests to run.
        /// </param>
        /// <param name="listener">
        /// A test listener needed by the <see cref="Runner"/> instance used to run the tests.
        /// </param>
        /// <param name="convention">
        /// The convetion being used when identifîng and runnng test cases.</param>
        /// <returns>The results of the test run.
        /// </returns>
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

        /// <summary>
        /// Gest the output that has has captured by the <see cref="RedirectedConsole"/> given by
        /// <paramref name="console"/>
        /// </summary>
        /// <param name="console">
        /// The <see cref="RedirectedConsole"/> that has captured console output.
        /// </param>
        /// <returns>
        /// The lines that have been written to the console.
        /// </returns>
        public static IEnumerable<string> Lines(this RedirectedConsole console)
        {
            if (console == null)
            {
                throw new ArgumentNullException(nameof(console));
            }

            return console.Output.Lines();
        }

        /// <summary>
        /// Splits a multi-line string given by <paramref name="multiline"/> into its constituent lines.
        /// </summary>
        /// <param name="multiline">
        /// The multi-line string assumed to consist of lines seperated by <see cref="Environment.NewLine"/>.
        /// </param>
        /// <returns>
        /// The constituent of the string given by <paramref name="multiline"/>
        /// </returns>
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

        /// <summary>
        /// Extension method to assert an enumeration given by <paramref name="actual"/> against a
        /// list of expected values given by <paramref name="expected"/>
        /// </summary>
        /// <typeparam name="T">
        /// The type of the elements in the enumeration.
        /// </typeparam>
        /// <param name="actual">
        /// The enumeration to assert.
        /// </param>
        /// <param name="expected">
        /// The list of expected values.
        /// </param>
        public static void ShouldEqual<T>(this IEnumerable<T> actual, params T[] expected)
        {
            actual.ToArray().ShouldBe(expected);
        }
    }
}
