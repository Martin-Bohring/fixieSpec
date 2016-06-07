// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using Fixie;
    using FixieSpec;

    public class SpecificationConvention : Convention
    {
        public SpecificationConvention()
        {
            Classes
                .Where(type => type.HasOnlyDefaultConstructor() || type.HasOnlyParameterConstructor());
        }
    }
}
