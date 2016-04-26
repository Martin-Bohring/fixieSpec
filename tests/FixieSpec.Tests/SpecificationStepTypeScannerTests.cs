// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Reflection;

    using Shouldly;

    public sealed class SpecificationStepTypeScannerTests
    {
        [Input("ToString")]
        [Input("GetHashCode")]
        [Input("GetType")]
        public void ShouldNotScanNonStepMethodsAsStep(string methodName)
        {
            var notAStep = typeof(object).GetMethod(methodName);

            var methodScanResult = notAStep.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Undefined);
        }

        [Input("Given_a_specification_context")]
        [Input("And_given_a_secondary_specification_context")]
        public void ShouldDetectSetupSteps(string methodName)
        {
            var setupStep = typeof(SampleSpec)
                .GetMethod(methodName);

            setupStep.IsSetupStep().ShouldBeTrue();
        }

        public void ShouldFailToDetectSetupStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsSetupStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldNotDetecMethodsWithParametersAsSetupSteps()
        {
            var notASetupStep = typeof(SampleSpec)
                .GetMethod("Given_not_a_setup_step");

            notASetupStep.IsSetupStep().ShouldBeFalse();
        }

        [Input("When_exercising_the_system_under_test")]
        [Input("And_when_exercising_the_system_under_test_some_more")]
        public void ShouldDetectTransitionSteps(string methodName)
        {
            var transitionStep = typeof(SampleSpec)
                .GetMethod(methodName);

            transitionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void ShouldFailToDetectTransitionStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsTransitionStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldNotDetecMethodsWithParametersAsTransitionSteps()
        {
            var notATransitionStep = typeof(SampleSpec)
                .GetMethod("When_not_exercising_a_transition_step");

            notATransitionStep.IsTransitionStep().ShouldBeFalse();
        }

        [Input("Then_a_result_can_be_verified")]
        [Input("And_then_another_result_can_be_verified")]
        public void ShouldDetectAssertionSteps(string methodName)
        {
            var assertionStep = typeof(SampleSpec)
                .GetMethod(methodName);

            assertionStep.IsAssertionStep().ShouldBeTrue();
        }

        public void ShouldFailToDetectAssertionStepForInvalidMethod()
        {
            Action act = () => (null as MethodInfo).IsAssertionStep();

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldNotDetecMethodsWithParametersAsAssertionSteps()
        {
            var notAnAssertionStep = typeof(SampleSpec)
                .GetMethod("Then_a_method_with_parameter_is_no_assertion_step");

            notAnAssertionStep.IsAssertionStep().ShouldBeFalse();
        }

        public void ShouldFailForInvalidMethodInfo()
        {
            Action act = () => ((MethodInfo)null).ScanMethod();

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
