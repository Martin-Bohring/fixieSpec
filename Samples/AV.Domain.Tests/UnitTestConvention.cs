// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace AV.Domain.Tests
{
    using System.Linq;

    using Fixie;
    using Shouldly;

    public class UnitTestConvention : Convention
    {
        public UnitTestConvention()
        {
            Classes
                .NameEndsWith("Tests")
                .Where(type => type.GetConstructors()
                .All(constructorInfo => !constructorInfo.GetParameters().Any()));

            Methods.Where(method => method.IsPublic && method.IsVoid());

            Parameters
                .Add<InputAttributeParameterSource>();

            HideExceptionDetails
                        .For<ShouldAssertException>()
                        .For<ShouldCompleteInException>();
        }
    }
}
