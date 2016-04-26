// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Reflection;

    using Shouldly;

    public sealed class ReflectionExtensionsTests
    {
        public void ShouldDetectMethodWithoutParameters()
        {
            var methodWithoutParameter = typeof(ReflectionTarget)
                .GetInstanceMethod("MethodWithOutParameter");

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void ShouldDetectMethodWithParameter()
        {
            var methodWithParameter = typeof(ReflectionTarget)
                .GetInstanceMethod("MethodWithParammeter");

            methodWithParameter.HasNoParameters().ShouldBeFalse();
        }

        public void ShouldFailToDetectParametersForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).HasNoParameters();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldDetectDefaultConstructor()
        {
            typeof(ReflectionTarget).HasOnlyDefaultConstructor().ShouldBeTrue();
        }

        public void ShouldFailToDetectDefaultConstructorForInvalidType()
        {
            Action act = () => (null as Type).HasOnlyDefaultConstructor();

            act.ShouldThrow<ArgumentNullException>();
        }

        class ReflectionTarget
        {
            public void MethodWithOutParameter()
            {
            }

            public void MethodWithParammeter(int value)
            {
                var notUsed = value;
            }
        }
    }
}
