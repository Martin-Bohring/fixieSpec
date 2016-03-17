// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>


namespace FixieSpec.Tests
{
    using Shouldly;

    public sealed class ReflectionExtensionsTests
    {
        public void ShouldIdentifyMethodWithoutParameters()
        {
            var methodWithoutParameter = SymbolExtensions.GetMethodInfo<ReflectionTarget>(c => c.MethodWithOutParameter());

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void ShouldIdentifyMethodWithParameter()
        {
            var methodWithParameter = SymbolExtensions.GetMethodInfo<ReflectionTarget>(c => c.MethodWithParammeter(5));

            methodWithParameter.HasNoParameters().ShouldBeFalse();
        }

        class ReflectionTarget
        {
            public void MethodWithOutParameter()
            {
            }

            public void MethodWithParammeter(int value)
            {
            }
        }
    }
}
