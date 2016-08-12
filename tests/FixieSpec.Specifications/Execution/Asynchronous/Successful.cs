// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution.Asynchronous
{
    using System.Threading.Tasks;

    using Shouldly;

    public sealed class Successful : ExecutionSpecificationBase
    {
        SpecificationExecutionResult successfulExecutionResult;

        public void When_executing_a_sucessful_asynchronous_specification()
        {
            successfulExecutionResult = Execute<SuccessfulAsynchronousSpecification>();
        }

        public void Then_all_specifiction_steps_should_execute_in_order()
        {
            successfulExecutionResult.ShouldHaveExecutedSteps(
                "Given_an_asynchronous_specification_context",
                "And_given_a_secondary_asynchronous_specification_context",
                "When_exercising_the_system_under_test_asynchronously",
                "And_when_exercising_the_system_under_test_asynchronously_some_more",
                "Then_an_asynchronous_result_can_be_verified",
                "And_then_another_asynchronous_result_can_be_verified");
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

        class SuccessfulAsynchronousSpecification
        {
            public async Task Given_an_asynchronous_specification_context()
            {
                WhereAmI();
                await Task.FromResult(true);
            }

            public async Task And_given_a_secondary_asynchronous_specification_context()
            {
                WhereAmI();
                await Task.FromResult(true);
            }

            public async Task When_exercising_the_system_under_test_asynchronously()
            {
                WhereAmI();
                await Task.FromResult(true);
            }

            public async Task And_when_exercising_the_system_under_test_asynchronously_some_more()
            {
                WhereAmI();
                await Task.FromResult(true);
            }

            public async Task Then_an_asynchronous_result_can_be_verified()
            {
                WhereAmI();
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
