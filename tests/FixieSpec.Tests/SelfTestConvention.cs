// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Linq;

    using Fixie;
    using Shouldly;

    public sealed class SelfTestConvention : Convention
    {
        public SelfTestConvention()
        {
            Classes
                .NameEndsWith("Tests")
                .InTheSameNamespaceAs(typeof(SelfTestConvention))
                .Where(type => type.HasOnlyDefaultConstructor());

            Methods.Where(method => method.IsPublic && method.IsVoid());

            Parameters
                .Add<InputAttributeParameterSource>();

            HideExceptionDetails
                        .For<ShouldAssertException>()
                        .For<ShouldCompleteInException>();
        }
    }
}
