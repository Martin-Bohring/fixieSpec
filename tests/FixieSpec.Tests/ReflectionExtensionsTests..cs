// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
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
            var methodWithoutParameter = Method("MethodWithOutParameter");

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void ShouldDetectMethodWithParameter()
        {
            var methodWithParameter = Method("MethodWithParammeter");

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

        static MethodInfo Method(string methodName)
        {
            return typeof(ReflectionTarget).GetInstanceMethod(methodName);
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
