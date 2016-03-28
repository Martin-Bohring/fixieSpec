// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fixie.Execution;
    using Shouldly;

    public sealed class FixieSpecConventionTests
    {
        public void ShouldExecuteSimpleSuccessfullSpecification()
        {
            var testRunResult = Run<SimpleSuccessfullSpecification>();

            testRunResult.Total.ShouldBe(1);
            testRunResult.Passed.ShouldBe(1);
            testRunResult.Failed.ShouldBe(0);
        }

        public void ShouldExecuteSimpleFailingSpecification()
        {
            var testRunResult = Run<SimpleFailingSpecification>();

            testRunResult.Total.ShouldBe(1);
            testRunResult.Failed.ShouldBe(1);
            testRunResult.Passed.ShouldBe(0);
        }

        public void ShouldExecuteSpecificationWithMultipleVerificationSteps()
        {
            var testRunResult = Run<MultipleVerificationStepsSpecification>();

            testRunResult.Total.ShouldBe(2);
            testRunResult.Passed.ShouldBe(2);
            testRunResult.Failed.ShouldBe(0);
        }

        public void ShouldExecuteMultipleVerificationStepsInOrder()
        {
            var testRunResult = Run<MultipleVerificationStepsSpecification>();

            testRunResult.CaseResults.First().MethodGroup.Method.ShouldBe(
                SymbolExtensions.GetMethodInfo<MultipleVerificationStepsSpecification>(c => c.Then_a_test_result_can_be_verified()).Name);

            testRunResult.CaseResults.Last().MethodGroup.Method.ShouldBe(
                SymbolExtensions.GetMethodInfo<MultipleVerificationStepsSpecification>(c => c.Then_another_test_result_can_be_verified()).Name);
        }

        static TestRunResult Run<TSampleTestClass>()
        {
            var listener = new StubCaseResultListener();

            var results = typeof(TSampleTestClass).Run(listener, new FixieSpecConvention());

            return new TestRunResult(results, listener.Log);
        }

        class TestRunResult
        {
            readonly AssemblyResult allResults;

            public TestRunResult(AssemblyResult results, List<CaseResult> caseResults)
            {
                allResults = results;
                CaseResults = caseResults;
            }

            public List<CaseResult> CaseResults { get; private set; }

            public int Passed
            {
                get
                {
                    return allResults.Passed;
                }
            }

            public int Failed
            {
                get
                {
                    return allResults.Failed;
                }
            }

            public int Total
            {
                get
                {
                    return allResults.Total;
                }
            }
        }

        class SimpleSuccessfullSpecification
        {
            public void Then_a_successfull_test_result_can_be_verified()
            {
            }
        }

        class SimpleFailingSpecification
        {
            public void Then_a_failing_test_result_can_be_verified()
            {
                throw new InvalidOperationException();
            }
        }

        class MultipleVerificationStepsSpecification
        {
            public void Then_a_test_result_can_be_verified()
            {
            }

            public void Then_another_test_result_can_be_verified()
            {
            }
        }

        public class StubCaseResultListener : Listener
        {
            public List<CaseResult> Log { get; set; } = new List<CaseResult>();

            public void AssemblyStarted(AssemblyInfo assembly) { }

            public void CaseSkipped(SkipResult result) => Log.Add(result);
            public void CasePassed(PassResult result) => Log.Add(result);
            public void CaseFailed(FailResult result) => Log.Add(result);

            public void AssemblyCompleted(AssemblyInfo assembly, AssemblyResult result) { }
        }
    }
}
