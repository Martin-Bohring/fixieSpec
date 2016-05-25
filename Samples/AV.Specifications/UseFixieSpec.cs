// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Fixie;
    using FixieSpec;

    class UseFixieSpec : TestAssembly
    {
        public UseFixieSpec()
        {
            Apply<FixieSpecConvention>();
        }
    }
}
