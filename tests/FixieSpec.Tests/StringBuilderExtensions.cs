// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Runtime.CompilerServices;
    using System.Text;
    using Shouldly;

    /// <summary>
    /// A small test helper class to verify the call order of test case methods/steps
    /// </summary>
    /// <remarks>
    /// Original from the Fixie samples https://github.com/fixie/fixie/blob/master/src/Fixie.Samples/StringBuilderExtensions.cs, but
    /// adapted to Shouldly.
    /// Maybe init makes sense to use https://github.com/approvals/ApprovalTests.Net in te future instead.
    /// </remarks>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Records the name of the method that is calling ths method.
        /// </summary>
        /// <param name="log">
        /// The <see cref="StringBuilder"/> used to record method calls.
        /// </param>
        /// <param name="method">
        /// The name of the method. This is automatically provided during run time.
        /// </param>
        public static void WhereAmI(this StringBuilder log, [CallerMemberName] string method = null)
        {
            log.AppendLine(method);
        }

        /// <summary>
        /// Verifies the method calls given by <paramref name="expected"/> have been recorded.
        /// </summary>
        /// <param name="log">
        /// The <see cref="StringBuilder"/> used to record method calls.
        /// </param>
        /// <param name="expected">
        /// The method calls in the order they should have been recorded.
        /// </param>
        public static void ShouldHaveLines(this StringBuilder log, params string[] expected)
        {
            var expectation = new StringBuilder();

            foreach (var line in expected)
                expectation.AppendLine(line);

            log.ToString().ShouldBe(expectation.ToString());
        }
    }
}