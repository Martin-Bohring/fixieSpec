// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Took the idea from
    /// https://github.com/fixie/fixie/blob/master/src/Fixie.Tests/ShouldBeUnreachableException.cs.
    /// </summary>
    [Serializable]
    public class ShouldBeUnreachableException : Exception
    {
        public ShouldBeUnreachableException([CallerMemberName] string member = null)
            : base($"'{member}' reached a line of code thought to be unreachable.")
        {}
    }
}
