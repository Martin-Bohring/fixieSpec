// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using System.Collections.Generic;
    using System.Linq;
    using Shouldly;

    /// <summary>
    /// Test helper extension class taken from
    /// https://github.com/fixie/fixie/blob/master/src/Fixie.Tests/TestExtensions.cs.
    /// </summary>
    static class AssertionExtensions
    {
        public static void ShouldEqual<T>(this IEnumerable<T> actual, params T[] expected)
        {
            actual.ToArray().ShouldBe(expected);
        }
    }
}
