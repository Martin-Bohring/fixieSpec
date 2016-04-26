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
            var setupStep = typeof(ReflectionTarget)
                .GetMethod("Given_some_specification_context_setup");

            setupStep.IsSetupStep().ShouldBeTrue();
        }

        public void ShouldFailToDetectSetupStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsSetupStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldNotDetecMethodsWithParametersAsSetupSteps()
        {
            var notASetupStep = typeof(ReflectionTarget)
                .GetMethod("Given_not_a_setup_step");

            notASetupStep.IsSetupStep().ShouldBeFalse();
        }

        public void ShouldDetectTransitionSteps()
        {
            var transitionStep = typeof(ReflectionTarget)
                .GetMethod("When_exercising_the_system_under_test");

            transitionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void ShouldFailToDetectTransitionStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsTransitionStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldNotDetecMethodsWithParametersAsTransitionSteps()
        {
            var notATransitionStep = typeof(ReflectionTarget)
                .GetMethod("When_not_exercising_a_transition_step");

            notATransitionStep.IsTransitionStep().ShouldBeFalse();
        }

        public void ShouldDetectAssertionSteps()
        {
            var assertionStep = typeof(ReflectionTarget)
                .GetMethod("Then_a_result_can_be_verified");

            assertionStep.IsAssertionStep().ShouldBeTrue();
        }

        public void ShouldFailToDetectAssertionStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsAssertionStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldNotDetecMethodsWithParametersAsAssertionSteps()
        {
            var notAnAssertionStep = typeof(ReflectionTarget)
                .GetMethod("Then_a_method_with_parameter_is_no_transitionStep");

            notAnAssertionStep.IsAssertionStep().ShouldBeFalse();
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

            public void Given_not_a_setup_step(int parameter)
            {
            }

            public void When_exercising_the_system_under_test()
            {
            }

            public void When_not_exercising_a_transition_step(int parameter)
            {
            }

            public void Then_a_result_can_be_verified()
            {
            }

            public void Then_a_method_with_parameter_is_no_transitionStep(int parameter)
            {

            }
        }
    }
}
