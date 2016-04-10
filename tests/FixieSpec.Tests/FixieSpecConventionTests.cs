// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using Fixie.Execution;
    using Fixie.Internal;
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

            testRunResult.ConsoleOutput.ShouldEqual(
                "Then_a_test_result_can_be_verified",
                "Then_another_test_result_can_be_verified");
        }

        public void ShouldExecuteMultipleVerificationStepsWithFailureInOrder()
        {
            var testRunResult = Run<MultipleVerificationStepsWithFailureSpecification>();

            testRunResult.ConsoleOutput.ShouldEqual(
                "Then_a_failing_result_can_be_verified",
                "Then_another_test_result_can_be_verified");
        }

        static void WhereAmI([CallerMemberName] string member = null)
        {
            Console.WriteLine(member);
        }

        static TestRunResult Run<TSampleTestClass>()
        {
            using (var console = new RedirectedConsole())
            {
                var listener = new NullResultListener();

                var results = typeof(TSampleTestClass).Run(listener, new FixieSpecConvention());

                return new TestRunResult(results, console.Lines());
            }
        }

        class TestRunResult
        {
            readonly AssemblyResult allResults;

            public TestRunResult(AssemblyResult results, IEnumerable<string> consoleOutput)
            {
                allResults = results;
                ConsoleOutput = consoleOutput;
            }

            public IEnumerable<string> ConsoleOutput { get; private set; }

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
                WhereAmI();
            }
        }

        class SimpleFailingSpecification
        {
            public void Then_a_failing_test_result_can_be_verified()
            {
                WhereAmI();
                true.ShouldBeFalse();
            }
        }

        class MultipleVerificationStepsSpecification
        {
            public void Then_a_test_result_can_be_verified()
            {
                WhereAmI();
            }

            public void Then_another_test_result_can_be_verified()
            {
                WhereAmI();
            }
        }

        class MultipleVerificationStepsWithFailureSpecification
        {
            public void Then_a_failing_result_can_be_verified()
            {
                WhereAmI();
                true.ShouldBeFalse();
            }

            public void Then_another_test_result_can_be_verified()
            {
                WhereAmI();
            }
        }

        public class NullResultListener : Listener
        {
            public void AssemblyStarted(AssemblyInfo assembly) { }

            public void CaseSkipped(SkipResult result) { }
            public void CasePassed(PassResult result) { }
            public void CaseFailed(FailResult result) { }

            public void AssemblyCompleted(AssemblyInfo assembly, AssemblyResult result) { }
        }
    }
}
