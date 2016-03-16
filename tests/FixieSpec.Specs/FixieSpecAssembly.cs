// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specs
{
    using Fixie;

    class FixieSpecAssembly : TestAssembly
    {
        public FixieSpecAssembly()
        {
            Apply<FixieSpecConvention>();
        }
    }
}
