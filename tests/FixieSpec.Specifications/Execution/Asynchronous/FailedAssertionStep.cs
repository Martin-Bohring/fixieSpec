// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution.Asynchronous
{
    using Shouldly;
    using System.Threading.Tasks;

    public sealed class FailedAssertionStep : FixieSpecSpecificationBase
    {
        SpecificationExecutionResult failedAssertionStepExecutionResult;

        public void When_executing_an_asynchronous_assertion_step_fails()
        {
            failedAssertionStepExecutionResult = Execute<FailingAsynchronousAssertionStepSpecification>();
        }

        public void Then_all_specifiction_steps_should_execute_in_order()
        {
            failedAssertionStepExecutionResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test_asynchronously",
                "Then_a_failing_asynchronous_result_can_be_verified",
                "And_then_another_asynchronous_result_can_be_verified");
        }

        public void And_then_all_assertion_steps_should_be_recognized()
        {
            failedAssertionStepExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_successful_assertion_steps_should_be_recognized()
        {
            failedAssertionStepExecutionResult.Passed.ShouldBe(1);
        }

        public void And_then_all_failed_assertion_steps_should_be_recognized()
        {
            failedAssertionStepExecutionResult.Failed.ShouldBe(1);
        }

        class FailingAsynchronousAssertionStepSpecification
        {
            public async Task When_exercising_the_system_under_test_asynchronously()
            {
                WhereAmI();
                await Task.FromResult(true);
            }

            public async Task Then_a_failing_asynchronous_result_can_be_verified()
            {
                WhereAmI();
                true.ShouldBeFalse();
                await Task.FromResult(true);
            }

            public async Task And_then_another_asynchronous_result_can_be_verified()
            {
                WhereAmI();
                await Task.FromResult(true);
            }
        }
    }
}
