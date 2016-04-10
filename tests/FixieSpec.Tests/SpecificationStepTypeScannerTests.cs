﻿// <copyright>
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
            var nonTestMethod = SymbolExtensions.GetMethodInfo<object>(c => c.ToString());

            var methodScanResult = nonTestMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Undefined);
        }

        public void ShouldScanSetupMethodAsSetupStep()
        {
            var contextTestMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.Given_a_simple_spec());

            var methodScanResult = contextTestMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Setup);
        }

        public void ShouldScanTransitionMethodAsTransitionStep()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.When_executing_a_test_step());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Transition);
        }

        public void ShouldScanAnotherTransitionMethodAsTransitionStep()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_when_executing_a_second_test_step());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Transition);
        }

        public void ShouldScanAssertionMethodAsAssertionStep()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.Then_a_test_result_can_be_verified());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Assertion);
        }

        public void ShouldScanAnotherAssertionMethodAsAssertionStep()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_then_a_second_result_can_be_verified());

            var methodScanResult = testExecutionMethod.ScanMethod();

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
