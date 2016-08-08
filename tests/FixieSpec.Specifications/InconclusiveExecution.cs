// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications
{
    using Shouldly;

    public sealed class InconclusiveExecution : FixieSpecSpecificationBase
    {
        SpecificationExecutionResult inconclusiveExecutionResult;

        public void When_attempting_to_execute_an_inconclusive_specification()
        {
            inconclusiveExecutionResult = Execute<InconclusiveSpecification>();
        }

        public void Then_no_specifiction_steps_should_execute()
        {
            inconclusiveExecutionResult.ConsoleOutput.ShouldBeEmpty();
        }

        public void And_then_all_specification_steps_should_be_recognized()
        {
            inconclusiveExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_all_assertion_steps_should_be_inconclusive()
        {
            inconclusiveExecutionResult.Skipped.ShouldBe(2);
        }

        public void And_then_no_successful_assertion_steps_should_be_recognized()
        {
            inconclusiveExecutionResult.Passed.ShouldBe(0);
        }

        public void And_then_there_should_be_no_failed_assertion_steps()
        {
            inconclusiveExecutionResult.Failed.ShouldBe(0);
        }

        [Inconclusive]
        class InconclusiveSpecification
        {
            public void Given_a_specification_context()
            {
                WhereAmI();
                throw new ShouldBeUnreachableException();
            }

            public void When_exercising_the_system_under_test()
            {
                WhereAmI();
                throw new ShouldBeUnreachableException();
            }

            public void Then_a_result_cannot_be_verified()
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
