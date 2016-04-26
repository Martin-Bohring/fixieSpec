﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Reflection;

    using Shouldly;

    public sealed class SpecificationStepScannerTests
    {
        [Input("Given_a_specification_context")]
        [Input("And_given_a_secondary_specification_context")]
        public void ShouldDetectSetupSteps(string methodName)
        {
            var setupStep = typeof(SampleSpec)
                .GetInstanceMethod(methodName);

            setupStep.IsSetupStep().ShouldBeTrue();
        }

        [Input("ToString")]
        [Input("GetHashCode")]
        [Input("GetType")]
        [Input("Equals")]
        [Input("Given_not_a_setup_step")]
        public void ShouldNotDetectNonStepMethodsAsSetupStep(string methodName)
        {
            var notASetupStep = typeof(SampleSpec)
                .GetInstanceMethod(methodName);

            notASetupStep.IsSetupStep().ShouldBeFalse();
        }

        public void ShouldFailToDetectSetupStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsSetupStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        [Input("When_exercising_the_system_under_test")]
        [Input("And_when_exercising_the_system_under_test_some_more")]
        public void ShouldDetectTransitionSteps(string methodName)
        {
            var transitionStep = typeof(SampleSpec)
                .GetInstanceMethod(methodName);

            transitionStep.IsTransitionStep().ShouldBeTrue();
        }

        [Input("ToString")]
        [Input("GetHashCode")]
        [Input("GetType")]
        [Input("Equals")]
        [Input("When_not_exercising_a_transition_step")]
        public void ShouldNotDetectNonStepMethodsAsTransitionStep(string methodName)
        {
            var notATransitionStep = typeof(SampleSpec)
                .GetInstanceMethod(methodName);

            notATransitionStep.IsTransitionStep().ShouldBeFalse();
        }

        public void ShouldFailToDetectTransitionStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsTransitionStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        [Input("Then_a_result_can_be_verified")]
        [Input("And_then_another_result_can_be_verified")]
        public void ShouldDetectAssertionSteps(string methodName)
        {
            var assertionStep = typeof(SampleSpec)
                .GetInstanceMethod(methodName);

            assertionStep.IsAssertionStep().ShouldBeTrue();
        }

        [Input("ToString")]
        [Input("GetHashCode")]
        [Input("GetType")]
        [Input("Equals")]
        [Input("Then_a_method_with_parameter_is_no_assertion_step")]
        public void ShouldNotDetecNonStepMethodsAsAssertionSteps(string methodName)
        {
            var notAnAssertionStep = typeof(SampleSpec)
                .GetInstanceMethod(methodName);

            notAnAssertionStep.IsAssertionStep().ShouldBeFalse();
        }

        public void ShouldFailToDetectAssertionStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsAssertionStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        sealed class SampleSpec
        {
            public void Given_a_specification_context()
            {
            }

            public void Given_not_a_setup_step(int parameter)
            {
                var notUsed = parameter;
            }

            public void And_given_a_secondary_specification_context()
            {
            }

            public void When_exercising_the_system_under_test()
            {
            }

            public void And_when_exercising_the_system_under_test_some_more()
            {
            }

            public void When_not_exercising_a_transition_step(int parameter)
            {
                var notUsed = parameter;

            }

            public void Then_a_result_can_be_verified()
            {
            }

            public void And_then_another_result_can_be_verified()
            {
            }

            public void Then_a_method_with_parameter_is_no_assertion_step(int parameter)
            {
                var notUsed = parameter;
            }
        }
    }
}
