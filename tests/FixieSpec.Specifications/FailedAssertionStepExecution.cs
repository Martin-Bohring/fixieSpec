// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>


namespace FixieSpec.Specifications
{
    using Shouldly;

    public sealed class FailedAssertionStepExecution : FixieSpecSpecificationBase
    {
        SpecificationExecutionResult failedExecutionResult;

        public void When_executing_an_assertion_step_fails()
        {
            failedExecutionResult = Execute<FailingAssertionStepSpecification>();
        }

        public void Then_all_specifiction_steps_should_execute_in_order()
        {
            failedExecutionResult.ConsoleOutput.ShouldEqual(
                "When_exercising_the_system_under_test",
                "And_when_exercising_the_system_under_test_some_more",
                "Then_a_failing_result_can_be_verified",
                "And_then_another_result_can_be_verified");
        }

        public void And_then_all_specification_steps_should_be_recognized()
        {
            failedExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_successful_assertion_steps_should_be_recognized()
        {
            failedExecutionResult.Passed.ShouldBe(1);
        }

        public void And_then_all_failed_assertion_steps_should_be_recognized()
        {
            failedExecutionResult.Failed.ShouldBe(1);
        }

        class FailingAssertionStepSpecification
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
    }
}
