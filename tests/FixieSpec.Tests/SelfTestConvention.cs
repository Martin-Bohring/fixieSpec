// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpecs.Tests
{
    using System.Linq;

    using Fixie;

    /// <summary>
    /// A Fixie test convention that resolves test case parameters using the <see cref="AutoFixtureParameterSource"/>.
    /// Test fixture class names need to end with "Tests".
    /// The test fixture class itself cannot have any constructor parameters.
    /// </summary>
    public class SelfTestConvention : Convention
    {
        public SelfTestConvention()
        {
            this.Classes
                .NameEndsWith("Tests")
                .Where(t =>
                    t.GetConstructors()
                    .All(ci => ci.GetParameters().Length == 0));

            this.Methods.Where(mi => mi.IsPublic && mi.IsVoid());

            this.Parameters.Add<AutoFixtureParameterSource>();
        }
    }
}
