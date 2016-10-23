// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;

    /// <summary>
    /// Can be used to mark assertion steps or whole specifications as inconclusive.
    /// Mostly used in situations where behaviour is specified that is not implemented yet
    /// when following a BDD approach.
    /// Inconclusive specifications are not considered as failed or skipped.
    /// </summary>
    /// <remarks>
    /// Currently implemented using the test skipping facilities of https://github.com/fixie/fixie,
    /// because inconclusive tests are not supported yet by fixie.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class InconclusiveAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InconclusiveAttribute"/> class.
        /// </summary>
        /// <param name="reason">
        /// The reason why the specified behaviour is inconclusive.
        /// </param>
        public InconclusiveAttribute(string reason = "")
        {
            Reason = reason;
        }

        /// <summary>
        /// Gets the reason why the specified behaviour is inconclusive.
        /// </summary>
        public string Reason { get; }
    }
}
