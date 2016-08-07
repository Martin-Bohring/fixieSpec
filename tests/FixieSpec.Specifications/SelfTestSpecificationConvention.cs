// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using FixieSpec;

    public class SelfTestSpecificationConvention : FixieSpecConvention
    {
        public SelfTestSpecificationConvention()
        {
            Classes
                .Where(type => type.HasOnlyDefaultConstructor())
                .Where(type => type.IsSubclassOf(typeof(FixieSpecSpecificationBase)));
        }
    }
}
