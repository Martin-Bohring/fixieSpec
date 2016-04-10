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
            var methodWithoutParameter = typeof(ReflectionTarget)
                .GetMethod("MethodWithOutParameter");

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void CanDetectMethodWithParameter()
        {
            var methodWithParameter = typeof(ReflectionTarget)
                .GetMethod("MethodWithParammeter");

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
            var transitionStep = typeof(ReflectionTarget)
                .GetMethod("When_exercising_the_system_under_test");

            transitionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void CanDetectAssertionSteps()
        {
            var assertionStep = typeof(ReflectionTarget)
                .GetMethod("Then_a_result_can_be_verified");

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
