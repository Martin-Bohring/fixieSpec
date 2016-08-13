// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution.Asynchronous
{
    using System;
    using System.Threading.Tasks;

    using Shouldly;

    public sealed class FailedSetupStep : ExecutionSpecificationBase
    {
        SpecificationExecutionResult failedSetupStepExecutionResult;

        public void When_executing_an_asynchronous_setup_step_fails()
        {
            failedSetupStepExecutionResult = Execute<FailingAsynchronousSetupStepSpecification>();
        }

        public void Then_the_execution_should_stop_after_the_failed_setup_step()
        {
            failedSetupStepExecutionResult.ShouldHaveExecutedSteps(
                "Given_an_asynchronous_setup_step_fails");
        }

        public void And_then_all_assertion_steps_should_be_recognized()
        {
            failedSetupStepExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_assertion_steps_should_fail()
        {
            failedSetupStepExecutionResult.Failed.ShouldBe(2);
        }

        public void And_then_there_should_be_no_successful_assertion_steps()
        {
            failedSetupStepExecutionResult.Passed.ShouldBe(0);
        }

        class FailingAsynchronousSetupStepSpecification
        {
            public async Task Given_an_asynchronous_setup_step_fails()
            {
                RecordStep();
                await Task.FromResult(true);
                throw new InvalidOperationException();
            }

            public async Task When_exercising_the_system_under_test()
            {
                RecordStep();
                await Task.FromResult(true);
                throw new ShouldBeUnreachableException();
            }

            public async Task Then_an_asynchronous_result_cannot_be_verified()
            {
                RecordStep();
                await Task.FromResult(true);
                throw new ShouldBeUnreachableException();
            }

            public async Task And_then_another_asynchronous_result_can_also_not_be_verified()
            {
                RecordStep();
                await Task.FromResult(true);
                throw new ShouldBeUnreachableException();
            }
        }
    }
}
