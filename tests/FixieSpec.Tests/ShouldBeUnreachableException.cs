// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// An exception class that should be thrown when a line of code has been reached
    /// that should not be reached.
    /// </summary>
    /// <remarks>
    /// Took the idea from
    /// https://github.com/fixie/fixie/blob/16c95a85ed0f747c821412d345cb6554e3a1656b/src/Fixie.Tests/ShouldBeUnreachableException.cs.
    /// </remarks>
    public class ShouldBeUnreachableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShouldBeUnreachableException"/> class.
        /// </summary>
        /// <param name="member">
        /// The name of the member the accidently reached source code lines is defined.
        /// </param>
        public ShouldBeUnreachableException([CallerMemberName] string member = null)
            : base($"'{member}' reached a line of code thought to be unreachable.")
        {}
    }
}
