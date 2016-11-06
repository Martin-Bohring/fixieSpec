// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Conventions.Steps
{
    using System.Reflection;
    using System.Threading.Tasks;

    using Shouldly;

    public sealed class When_detecting_transition_steps
    {
        readonly MethodInfo transitionStep = Method("When_exercising_the_system_under_test");
        readonly MethodInfo additionalTransitionStep = Method("And_when_exercising_the_system_under_test_some_more");
        readonly MethodInfo otherMethod = Method("ToString");
        readonly MethodInfo methodWithParameter = Method("And_when_a_non_transition_step_has_parameters");
        readonly MethodInfo methodWithReturnValue = Method("And_when_a_non_transition_step_returns_a_value");

       public void Then_transition_steps_are_detected_as_transition_steps()
        {
            transitionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void And_then_additional_transition_steps_are_detected_as_additional_transition_steps()
        {
            additionalTransitionStep.IsTransitionStep().ShouldBeTrue();
        }

        public void And_then_other_methods_are_not_detected_as_transition_steps()
        {
            otherMethod.IsTransitionStep().ShouldBeFalse();
        }

        public void And_then_methods_with_parameters_are_not_detected_as_transition_steps()
        {
            methodWithParameter.IsTransitionStep().ShouldBeFalse();
        }

        public void And_then_methods_with_return_values_are_not_detected_as_transition_steps()
        {
            methodWithReturnValue.IsTransitionStep().ShouldBeFalse();
        }

        static MethodInfo Method(string methodName)
        {
            return typeof(SpecificationWithTransitionSteps).GetInstanceMethod(methodName);
        }

        sealed class SpecificationWithTransitionSteps
        {
            public void When_exercising_the_system_under_test()
            {
            }

            public async Task And_when_exercising_the_system_under_test_some_more()
            {
                await Task.FromResult(true);
            }

            public void And_when_a_non_transition_step_has_parameters(int parameter)
            {
                var notUsed = parameter;

            }

            public int And_when_a_non_transition_step_returns_a_value()
            {
                return 0;
            }
        }
    }
}
