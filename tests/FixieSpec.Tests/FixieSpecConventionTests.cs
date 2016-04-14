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
        public void ShouldExecuteAllStepsInOrder()
        {
            var testRunResult = Execute<ExampleSpecification>();

            testRunResult.ConsoleOutput.ShouldEqual(
                "Given_a_specification_context",
                "And_given_a_secondary_specification_context",
                "When_exercising_the_system_under_test",
                "And_when_exercising_the_system_under_test_some_more",
                "Then_a_result_can_be_verified",
                "And_then_another_result_can_be_verified");
        }

        public void ShouldRecognizeSuccessfulAssertionSteps()
        {
            var testRunResult = Execute<ExampleSpecification>();

            testRunResult.Total.ShouldBe(2);
            testRunResult.Passed.ShouldBe(2);
            testRunResult.Failed.ShouldBe(0);
        }

        public void ShouldExecuteAllStepsInOrderEvenWithFailingAssertionSteps()
        {
            var testRunResult = Execute<FailingAssertionStepExampleSpecification>();

            testRunResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test",
                "And_when_exercising_the_system_under_test_some_more",
                "Then_a_failing_result_can_be_verified",
                "And_then_another_result_can_be_verified");
        }

        public void ShouldRecognizeFailedAssertionSteps()
        {
            var testRunResult = Execute<FailingAssertionStepExampleSpecification>();

            testRunResult.Total.ShouldBe(2);
            testRunResult.Passed.ShouldBe(1);
            testRunResult.Failed.ShouldBe(1);
        }

        public void ShouldFailWhenATransitionStepFails()
        {
            var testRunResult = Execute<FailingTransitionStepExampleSpecification>();

            testRunResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test_fails");

            testRunResult.Failed.ShouldBe(1);
        }

        public void ShouldStopWhenASetupStepFails()
        {
            var testRunResult = Execute<FailingSetupStepExampleSpecification>();

            testRunResult.ConsoleOutput.ShouldEqual(
                "Given_a_specification_context",
                "And_given_a_secondary_setup_step_fails");
        }

        public void ShouldFailAllAssertionStepsWhenASetupStepFails()
        {
            var testRunResult = Execute<FailingSetupStepExampleSpecification>();

            testRunResult.Failed.ShouldBe(2);
        }

        class ExampleSpecification
        {
            public void Given_a_specification_context()
            {
                WhereAmI();
            }

            public void And_given_a_secondary_specification_context()
            {
                WhereAmI();
            }

            public void When_exercising_the_system_under_test()
            {
                WhereAmI();
            }

            public void And_when_exercising_the_system_under_test_some_more()
            {
                WhereAmI();
            }

            public void Then_a_result_can_be_verified()
            {
                WhereAmI();
            }

            public void And_then_another_result_can_be_verified()
            {
                WhereAmI();
            }
        }
 
        class FailingAssertionStepExampleSpecification
        {
            public void When_exercising_the_system_under_test()
            {
                WhereAmI();
            }

            public void And_when_exercising_the_system_under_test_some_more()
            {
                WhereAmI();
            }

            public void Then_a_failing_result_can_be_verified()
            {
                WhereAmI();
                true.ShouldBeFalse();
            }

            public void And_then_another_result_can_be_verified()
            {
                WhereAmI();
            }
        }

        class FailingTransitionStepExampleSpecification
        {
            public void When_exercising_the_system_under_test_fails()
            {
                WhereAmI();

                throw new InvalidOperationException();
            }

            public void And_when_exercising_the_system_under_test_some_more()
            {
                throw new ShouldBeUnreachableException();
            }

            public void Then_the_result_cannot_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }
        }

        class FailingSetupStepExampleSpecification
        {
            public void Given_a_specification_context()
            {
                WhereAmI();
            }

            public void And_given_a_secondary_setup_step_fails()
            {
                WhereAmI();

                throw new InvalidOperationException();
            }

            public void When_exercising_the_system_under_test()
            {
                throw new ShouldBeUnreachableException();
            }

            public void Then_the_result_cannot_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }

            public void And_then_a_second_result_can_also_not_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }
        }

        static SpecificationExecutionResult Execute<TSampleTestClass>()
        {
            using (var console = new RedirectedConsole())
            {
                var listener = new NullResultListener();

                var results = typeof(TSampleTestClass).Run(listener, new FixieSpecConvention());

                return new SpecificationExecutionResult(results, console.Lines());
            }
        }

        static void WhereAmI([CallerMemberName] string member = null)
        {
            Console.WriteLine(member);
        }

        class SpecificationExecutionResult
        {
            readonly AssemblyResult allResults;

            public SpecificationExecutionResult(AssemblyResult results, IEnumerable<string> consoleOutput)
            {
                allResults = results;
                ConsoleOutput = consoleOutput;
            }

            public IEnumerable<string> ConsoleOutput { get; private set; }

            public int Passed => allResults.Passed;

            public int Failed => allResults.Failed;

            public int Total => allResults.Total;
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
