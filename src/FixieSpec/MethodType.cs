// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    /// <summary>
    /// Describes the type of a method scanned from a specification.
    /// </summary>
    public enum MethodType
    {
        /// <summary>
        /// The type of the method is unknown.
        /// </summary>
        Undefined,

        /// <summary>
        /// The method is a test context setup method.
        /// </summary>
        Given,

        /// <summary>
        /// The method is a test case execution method,
        /// </summary>
        When,

        /// <summary>
        /// The method is a test case verification method.
        /// </summary>
        Then
    }
}
