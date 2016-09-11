// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using Fixie;

    public sealed class SelfSpecificationConvention : FixieSpecConvention
    {
        public SelfSpecificationConvention()
        {
            Classes
                .Where(type => !type.IsNested)
                .Where(type => type.HasOnlyDefaultConstructor())
                .Where(type => type.IsInNamespace("FixieSpec.Specifications"));
        }
    }
}
