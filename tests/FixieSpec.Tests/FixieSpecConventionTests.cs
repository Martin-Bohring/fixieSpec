// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using Fixie.Execution;
    using Fixie.Internal;
    using Shouldly;

    public sealed class FixieSpecConventionTests
    {
        public void ShouldExecuteAllStepsOnTheSameInstance()
        {
            var executionResult = Execute<ExampleWithInstance>();

            executionResult.Total.ShouldBe(1);
            executionResult.Passed.ShouldBe(1);
        }

        public void ShouldExecuteAllStepsInOrderEvenWithFailingAssertionSteps()
        {
            var executionResult = Execute<FailingAssertionStepExample>();

            executionResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test",
                "And_when_exercising_the_system_under_test_some_more",
                "Then_a_failing_result_can_be_verified",
                "And_then_another_result_can_be_verified");
        }

        public void ShouldRecognizeAllFailedAssertionSteps()
        {
            var executionResult = Execute<FailingAssertionStepExample>();

            executionResult.Total.ShouldBe(2);
            executionResult.Passed.ShouldBe(1);
            executionResult.Failed.ShouldBe(1);
        }

        public void ShouldStopWhenASetupStepFails()
        {
            var executionResult = Execute<FailingSetupStepExample>();

            executionResult.ConsoleOutput.ShouldEqual(
                "Given_a_specification_context",
                "And_given_a_secondary_setup_step_fails");
        }

        public void ShouldFailAllAssertionStepsWhenASetupStepFails()
        {
            var executionResult = Execute<FailingSetupStepExample>();

            executionResult.Failed.ShouldBe(2);
        }

        public void ShouldStopWhenATransitionStepFails()
        {
            var executionResult = Execute<FailingTransitionStepExample>();

            executionResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test_fails");
        }

        public void ShouldStopWhenAnAsynchronousTransitionStepFails()
        {
            var executionResult = Execute<FailingAsynchronousTransitionStepExample>();

            executionResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test_asynchronously_fails");
        }

        public void ShouldFailAllAssertionStepsWhenATransitionStepFails()
        {
            var executionResult = Execute<FailingTransitionStepExample>();

            executionResult.Failed.ShouldBe(2);
        }

        public void ShouldFailAllAssertionStepsWhenAnAsynchronousTransitionStepFails()
        {
            var executionResult = Execute<FailingAsynchronousTransitionStepExample>();

            executionResult.Failed.ShouldBe(2);
        }

        public void ShouldRecognizenInconclusiveSpecifications()
        {
            var executionResult = Execute<InconclusiveExample>();

            executionResult.Skipped.ShouldBe(1);
        }
        
        public void ShouldRecognizeInconclusiveAssertionSteps()
        {
            var executionResult = Execute<InconclusiveStepExample>();

            executionResult.Total.ShouldBe(2);
            executionResult.Skipped.ShouldBe(1);
            executionResult.Passed.ShouldBe(1);
        }

        public void ShouldNotExecuteInconclusiveAssertionSteps()
        {
            var executionResult = Execute<InconclusiveStepExample>();

            executionResult.ConsoleOutput.ShouldEqual(
                "Given_a_specification_context",
                "When_exercising_the_system_under_test",
                "And_then_another_result_can_be_verified");
        }

        class ExampleWithInstance
        {
            Instance instance;

            public void Given_an_instance()
            {
                instance = new Instance();
            }

            public void When_working_with_the_instance()
            {
                instance.Value = 42;
            }

            public void Then_a_result_can_be_verified()
            {
                instance.Value.ShouldBe(42);
            }

            class Instance
            {
                public int Value { get; set; }
            }
        }

        class FailingAssertionStepExample
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
        class FailingSetupStepExample
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

            public void And_then_another_result_can_also_not_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }
        }

        class FailingTransitionStepExample
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

            public void And_then_another_result_can_also_not_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }
        }

        class FailingAsynchronousTransitionStepExample
        {
            public async Task When_exercising_the_system_under_test_asynchronously_fails()
            {
                WhereAmI();

                await Task.FromResult(true);

                throw new InvalidOperationException();
            }

            public void And_when_exercising_the_system_under_test_some_more()
            {
                throw new ShouldBeUnreachableException();
            }

            public async Task Then_an_asynchronous_result_cannot_be_verified()
            {
                await Task.FromResult(true);

                throw new ShouldBeUnreachableException();
            }

            public void And_then_another_result_can_also_not_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }
        }

        [Inconclusive]
        class InconclusiveExample
        {
            public void Given_a_specification_context()
            {
                WhereAmI();
            }

            public void When_exercising_the_system_under_test()
            {
                WhereAmI();
            }

            public void Then_a_result_cannot_be_verified()
            {
                throw new ShouldBeUnreachableException();
            }
        }

        class InconclusiveStepExample
        {
            public void Given_a_specification_context()
            {
                WhereAmI();
            }

            public void When_exercising_the_system_under_test()
            {
                WhereAmI();
            }

            [Inconclusive]
            public void Then_an_inconclusive_result_is_skipped()
            {
                throw new ShouldBeUnreachableException();
            }

            public void And_then_another_result_can_be_verified()
            {
                WhereAmI();
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

            public int Skipped => allResults.Skipped;

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
