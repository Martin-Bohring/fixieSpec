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
            var nonStepMethod = typeof(object).GetMethod(methodName);

            var methodScanResult = nonStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Undefined);
        }

        public void ShouldDetectSetupSteps()
        {
            var setupStep = typeof(SampleSpec)
                .GetMethod("Given_a_specification_context");

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

        public void ShouldDetectTransitionSteps()
        {
            var transitionStep = typeof(SampleSpec)
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
            var notATransitionStep = typeof(SampleSpec)
                .GetMethod("When_not_exercising_a_transition_step");

            notATransitionStep.IsTransitionStep().ShouldBeFalse();
        }

        public void ShouldDetectAssertionSteps()
        {
            var assertionStep = typeof(SampleSpec)
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
            var notAnAssertionStep = typeof(SampleSpec)
                .GetMethod("Then_a_method_with_parameter_is_no_transitionStep");

            notAnAssertionStep.IsAssertionStep().ShouldBeFalse();
        }

        public void ShouldScanAnotherSetupMethodAsSetupStep()
        {
            var anotherSetupStep = typeof(SampleSpec).GetMethod("And_given_a_secondary_specification_context");

            var methodScanResult = anotherSetupStep.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Setup);
        }

        public void ShouldScanTransitionMethodAsTransitionStep()
        {
            var transitionStepMethod = typeof(SampleSpec).GetMethod("When_exercising_the_system_under_test");

            var methodScanResult = transitionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Transition);
        }

        public void ShouldScanAnotherTransitionMethodAsTransitionStep()
        {
            var anotherTransitionStepMethod = typeof(SampleSpec).GetMethod("And_when_exercising_the_system_under_test_some_more");

            var methodScanResult = anotherTransitionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Transition);
        }

        public void ShouldScanAssertionMethodAsAssertionStep()
        {
            var assertionStepMethod = typeof(SampleSpec).GetMethod("Then_a_result_can_be_verified");

            var methodScanResult = assertionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Assertion);
        }

        public void ShouldScanAnotherAssertionMethodAsAssertionStep()
        {
            var anotherAssertionStepMethod = typeof(SampleSpec).GetMethod("And_then_another_result_can_be_verified");

            var methodScanResult = anotherAssertionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Assertion);
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

            public void Then_a_method_with_parameter_is_no_transitionStep(int parameter)
            {
                var notUsed = parameter;
            }
        }
    }
}
