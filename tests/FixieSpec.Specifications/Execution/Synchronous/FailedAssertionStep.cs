// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution.Synchronous
{
    using Shouldly;

    public sealed class FailedAssertionStep : ExecutionSpecificationBase
    {
        SpecificationExecutionResult failedAssertionStepExecutionResult;

        public void When_executing_an_assertion_step_fails()
        {
            failedAssertionStepExecutionResult = Execute<FailingAssertionStepSpecification>();
        }

        public void Then_all_specifiction_steps_should_execute_in_order()
        {
            failedAssertionStepExecutionResult.ShouldHaveExecutedSteps(
                "When_exercising_the_system_under_test",
                "Then_a_failing_result_can_be_verified",
                "And_then_another_result_can_be_verified");
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

        class FailingAssertionStepSpecification
        {
            public void When_exercising_the_system_under_test()
            {
                RecordStep();
            }

            public void Then_a_failing_result_can_be_verified()
            {
                RecordStep();
                true.ShouldBeFalse();
            }

            public void And_then_another_result_can_be_verified()
            {
                RecordStep();
            }
        }
    }
}
