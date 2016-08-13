// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution.Synchronous
{
    using Shouldly;

    public sealed class Successful : ExecutionSpecificationBase
    {
        SpecificationExecutionResult successfulExecutionResult;

        public void When_executing_a_sucessful_specification()
        {
            successfulExecutionResult = Execute<SuccessfulSpecification>();
        }

        public void Then_all_specifiction_steps_should_execute_in_order()
        {
            successfulExecutionResult.ShouldHaveExecutedSteps(
                "Given_a_specification_context",
                "And_given_a_secondary_specification_context",
                "When_exercising_the_system_under_test",
                "And_when_exercising_the_system_under_test_some_more",
                "Then_a_result_can_be_verified",
                "And_then_another_result_can_be_verified");
        }

        public void And_then_all_assertion_steps_should_be_recognized()
        {
            successfulExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_successful_assertion_steps_should_be_recognized()
        {
            successfulExecutionResult.Passed.ShouldBe(2);
        }

        public void And_then_there_should_be_no_failed_assertion_steps()
        {
            successfulExecutionResult.Failed.ShouldBe(0);
        }

        class SuccessfulSpecification
        {
            const int SomeValue = 42;
            const int SomeOtherValue = 4711;

            SpecificationContext systemUnderTest;

            public void Given_a_specification_context()
            {
                systemUnderTest = new SpecificationContext();
                RecordStep();
            }

            public void And_given_a_secondary_specification_context()
            {
                RecordStep();
            }

            public void When_exercising_the_system_under_test()
            {
                systemUnderTest.Value = SomeValue;
                RecordStep();
            }

            public void And_when_exercising_the_system_under_test_some_more()
            {
                systemUnderTest.AnotherValue = SomeOtherValue;
                RecordStep();
            }

            public void Then_a_result_can_be_verified()
            {
                systemUnderTest.Value.ShouldBe(SomeValue);
                RecordStep();
            }

            public void And_then_another_result_can_be_verified()
            {
                systemUnderTest.AnotherValue.ShouldBe(SomeOtherValue);
                RecordStep();
            }

            class SpecificationContext
            {
                public int Value { get; set; }
                public int AnotherValue { get; set; }
            }
        }
    }
}
