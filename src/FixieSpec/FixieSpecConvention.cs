// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System.Linq;

    using Fixie;

    /// <summary>
    /// A class that describes a Fixie test case conventions that mimics
    /// BDD style style test fixtures.
    /// </summary>
    public class FixieSpecConvention : Convention
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixieSpecConvention"/> class.
        /// </summary>
        public FixieSpecConvention()
        {
            Classes
                .NameEndsWith("Specs")
            .Where(t =>
                t.GetConstructors().Count() == 1
                && t.GetConstructors().Count(ci => ci.GetParameters().Length > 0) == 1);
        }
    }
}
