// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using System;

    using Fixie;
    using FixieSpec;
    using Ploeh.AutoFixture.Kernel;
    using Fixture = Ploeh.AutoFixture.Fixture;


    public class SpecificationConvention : Convention
    {
        public SpecificationConvention()
        {
            Classes
                .Where(type => type.HasOnlyDefaultConstructor() || type.HasOnlyParameterConstructor());

            ClassExecution
                .UsingFactory(CreateFromFixture);
        }

        object CreateFromFixture(Type type)
        {
            var fixture = new Fixture();

            return new SpecimenContext(fixture).Resolve(type);
        }
    }
}
