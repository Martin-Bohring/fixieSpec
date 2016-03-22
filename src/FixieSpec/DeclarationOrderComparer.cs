// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// An <see cref="IComparer{T}"/> implementation that compares the declaration order of
    /// <see cref="MemberInfo"/> elements of types.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="MemberInfo"/> to compare.
    /// </typeparam>
    /// <remarks>
    /// There are doubts if this implementation is using .Net framework implementation specific
    /// properties and if it might fail in other implementation of the CLR.
    /// </remarks>
    public class DeclarationOrderComparer<T> : IComparer<T>
        where T : MemberInfo
    {
        /// <inheritdoc/>
        public int Compare(T first, T second)
        {
            if (first == null)
            {
                return second != null ? -1 : 0;
            }

            if (second == null)
            {
                return 1;
            }

            return first.MetadataToken.CompareTo(second.MetadataToken);
        }
    }
}
