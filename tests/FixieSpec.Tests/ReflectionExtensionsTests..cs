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
        public void CanDetectMethodWithoutParameters()
        {
            var methodWithoutParameter = SymbolExtensions.GetMethodInfo<ReflectionTarget>
                (c => c.MethodWithOutParameter());

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void CanDetectMethodWithParameter()
        {
            var methodWithParameter = SymbolExtensions.GetMethodInfo<ReflectionTarget>
                (c => c.MethodWithParammeter(5));

            methodWithParameter.HasNoParameters().ShouldBeFalse();
        }

        public void ShoulfFailForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).HasNoParameters();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void CanDetectDefaultConstructor()
        {
            typeof(ReflectionTarget).HasOnlyDefaultConstructor().ShouldBeTrue();
        }

        public void ShouldFailForInvalidType()
        {
            Action act = () => (null as Type).HasOnlyDefaultConstructor();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void CanDetectTransitionSteps()
        {
            var assertionStep = SymbolExtensions.GetMethodInfo<ReflectionTarget>
                (c => c.When_exercising_the_system_under_test());

            assertionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void CanDetectAssertionSteps()
        {
            var assertionStep = SymbolExtensions.GetMethodInfo<ReflectionTarget>
                (c => c.Then_a_result_can_be_verified());

            assertionStep.IsAssertionStep().ShouldBeTrue();
        }

        class ReflectionTarget
        {
            public void MethodWithOutParameter()
            {
            }

            public void MethodWithParammeter(int value)
            {
            }

            public void When_exercising_the_system_under_test()
            {
            }

            public void Then_a_result_can_be_verified()
            {
            }
        }
    }
}
