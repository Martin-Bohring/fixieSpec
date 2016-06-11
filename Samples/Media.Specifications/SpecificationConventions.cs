// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Specifications
{
    using System;
    using FixieSpec;
    using Ploeh.AutoFixture.Kernel;
    using Fixture = Ploeh.AutoFixture.Fixture;


    public class SpecificationConvention : FixieSpecConvention
    {
        public SpecificationConvention()
        {
            Classes
                .Where(type => type.HasOnlyDefaultConstructor() || type.HasOnlyParameterConstructor());

            ClassExecution
                .CreateInstancePerClass()
                .SortCases((firstCase, secondCase) => DeclarationOrderComparer.Default.Compare(firstCase.Method, secondCase.Method))
                .UsingFactory(CreateFromFixture);
        }

        object CreateFromFixture(Type type)
        {
            var fixture = new Fixture();

            var instance = new SpecimenContext(fixture).Resolve(type);

            return instance;
        }
    }
}
