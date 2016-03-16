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
        public void ShouldNotScanNonTestMethodsAsTestMethods()
        {
            var nonTestMethod = SymbolExtensions.GetMethodInfo<object>(c => c.ToString());

            var methodScanResult = nonTestMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Undefined);
        }

        public void ShouldScanContextMethodAsContextMethod()
        {
            var contextTestMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.Given_a_simple_spec());

            var methodScanResult = contextTestMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Given);
        }

        public void ShouldScanTestExectionMethodAsExecutionMethod()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.When_executing_a_test_step());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.When);
        }

        public void ShouldScanSecondTestExectionMethodAsExecutionMethod()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_when_executing_a_second_test_step());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.When);
        }

        public void ShouldScanTestVerificationMethodAsVerificationMethod()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.Then_a_test_result_can_be_verified());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Then);
        }

        public void ShouldScanSecondTestVerificationMethodAsVerificationMethod()
        {
            var testExecutionMethod = SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_then_a_second_result_can_be_verified());

            var methodScanResult = testExecutionMethod.ScanMethod();

            methodScanResult.ShouldBe(SpecificationStepType.Then);
        }

        public void ShouldFailForInvalidMethoodInfo()
        {
            Action act = () => ((MethodInfo)null).ScanMethod();

            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
