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
