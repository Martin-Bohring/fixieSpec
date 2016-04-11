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
        public void ShouldNotScanNonStepMethodsAsStep()
        {
            var nonStepMethod = typeof(object).GetMethod("ToString");

            var methodScanResult = nonStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Undefined);
        }

        public void ShouldScanSetupMethodAsSetupStep()
        {
            var setupStepMethod = typeof(SimpleSpec).GetMethod("Given_a_simple_spec");

            var methodScanResult = setupStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Setup);
        }

        public void ShouldScanAnotherSetupMethodAsSetupStep()
        {
            var anotherSetupStep = typeof(SimpleSpec).GetMethod("And_given_some_more_context_setup");

            var methodScanResult = anotherSetupStep.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Setup);
        }

        public void ShouldScanTransitionMethodAsTransitionStep()
        {
            var transitionStepMethod = typeof(SimpleSpec).GetMethod("When_executing_a_test_step");

            var methodScanResult = transitionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Transition);
        }

        public void ShouldScanAnotherTransitionMethodAsTransitionStep()
        {
            var anotherTransitionStepMethod = typeof(SimpleSpec).GetMethod("And_when_executing_a_second_test_step");

            var methodScanResult = anotherTransitionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Transition);
        }

        public void ShouldScanAssertionMethodAsAssertionStep()
        {
            var assertionStepMethod = typeof(SimpleSpec).GetMethod("Then_a_test_result_can_be_verified");

            var methodScanResult = assertionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Assertion);
        }

        public void ShouldScanAnotherAssertionMethodAsAssertionStep()
        {
            var anotherAssertionStepMethod = typeof(SimpleSpec).GetMethod("And_then_a_second_result_can_be_verified");

            var methodScanResult = anotherAssertionStepMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Assertion);
        }

        public void ShouldFailForInvalidMethodInfo()
        {
            Action act = () => ((MethodInfo)null).ScanMethod();

            act.ShouldThrow<ArgumentNullException>();
        }

        sealed class SimpleSpec
        {
            public void Given_a_simple_spec()
            {
            }

            public void And_given_some_more_context_setup()
            {
            }

            public void When_executing_a_test_step()
            {
            }

            public void And_when_executing_a_second_test_step()
            {
            }

            public void Then_a_test_result_can_be_verified()
            {
            }

            public void And_then_a_second_result_can_be_verified()
            {
            }
        }
    }
}
