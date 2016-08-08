// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using System;

    using Shouldly;

    public sealed class FailedTransitionStepExecution : FixieSpecSpecificationBase
    {
        SpecificationExecutionResult failedTransitionStepExecutionResult;

        public void When_executing_a_transition_step_fails()
        {
            failedTransitionStepExecutionResult = Execute<FailingTransitionStepSpecification>();
        }

        public void Then_the_execution_should_stop_after_the_failed_transition_step()
        {
            failedTransitionStepExecutionResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test_fails");
        }

        public void And_then_all_specification_steps_should_be_recognized()
        {
            failedTransitionStepExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_assertion_steps_should_fail()
        {
            failedTransitionStepExecutionResult.Failed.ShouldBe(2);
        }

        public void And_then_there_should_be_no_successful_assertion_steps()
        {
            failedTransitionStepExecutionResult.Passed.ShouldBe(0);
        }

        class FailingTransitionStepSpecification
        {
            public void When_exercising_the_system_under_test_fails()
            {
                WhereAmI();
                throw new InvalidOperationException();
            }

            public void Then_the_result_cannot_be_verified()
            {
                WhereAmI();
                throw new ShouldBeUnreachableException();
            }

            public void And_then_another_result_can_also_not_be_verified()
            {
                WhereAmI();
                throw new ShouldBeUnreachableException();
            }
        }
    }
}
