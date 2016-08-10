// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using System;

    using Shouldly;

    public sealed class FailedSetupStepExecution : FixieSpecSpecificationBase
    {
        SpecificationExecutionResult failedSetupStepExecutionResult;

        public void When_executing_a_setup_step_fails()
        {
            failedSetupStepExecutionResult = Execute<FailingSetupStepSpecification>();
        }

        public void Then_the_execution_should_stop_after_the_failed_setup_step()
        {
            failedSetupStepExecutionResult.ConsoleOutput.ShouldEqual(
                "Given_a_setup_step_fails");
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

        class FailingSetupStepSpecification
        {
            public void Given_a_setup_step_fails()
            {
                WhereAmI();
                throw new InvalidOperationException();
            }

            public void When_exercising_the_system_under_test()
            {
                WhereAmI();
                throw new ShouldBeUnreachableException();
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
