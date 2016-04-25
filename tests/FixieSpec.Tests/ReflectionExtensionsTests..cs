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
                .GetMethod("MethodWithOutParameter");

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
        }

        public void ShouldDetectMethodWithParameter()
        {
            var methodWithParameter = typeof(ReflectionTarget)
                .GetMethod("MethodWithParammeter");

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

        public void ShouldDetectSetupSteps()
        {
            var transitionStep = typeof(ReflectionTarget)
                .GetMethod("Given_some_specification_context_setup");

            transitionStep.IsSetupStep().ShouldBeTrue();
        }

        public void ShouldDetectTransitionSteps()
        {
            var transitionStep = typeof(ReflectionTarget)
                .GetMethod("When_exercising_the_system_under_test");

            transitionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void ShouldDetectAssertionSteps()
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

            public void Given_some_specification_context_setup()
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
