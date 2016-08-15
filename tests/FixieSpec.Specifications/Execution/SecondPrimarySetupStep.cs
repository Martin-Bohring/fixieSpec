// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution
{
    using Shouldly;

    [Inconclusive]
    public sealed class SecondPrimarySetupStep : ExecutionSpecificationBase
    {
        SpecificationExecutionResult secondPrimarySetupStepExecutionResult;

        public void When_a_executing_specification_having_a_second_primary_step()
        {
            secondPrimarySetupStepExecutionResult = Execute<SecondPrimarySetupStepSpecification>();
        }

        public void Then_the_specification_should_not_execute()
        {
            secondPrimarySetupStepExecutionResult.ShouldNotHaveExecutedAnySteps();
        }

        public void And_then_all_assertion_steps_should_be_recognized()
        {
            secondPrimarySetupStepExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_assertion_steps_should_fail()
        {
            secondPrimarySetupStepExecutionResult.Failed.ShouldBe(2);
        }

        public void And_then_there_should_be_no_successful_assertion_steps()
        {
            secondPrimarySetupStepExecutionResult.Passed.ShouldBe(0);
        }

        class SecondPrimarySetupStepSpecification
        {
            public void Given_a_primary_setup_step()
            {
                RecordStep();
            }

            public void Given_a_second_primary_setup_step()
            {
                RecordStep();
                throw new ShouldBeUnreachableException();
            }

            public void Then_the_result_cannot_be_verified()
            {
                RecordStep();
                throw new ShouldBeUnreachableException();
            }

            public void And_then_another_result_can_also_not_be_verified()
            {
                RecordStep();
                throw new ShouldBeUnreachableException();
            }
        }
    }
}
