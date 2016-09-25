// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Conventions.Steps
{
    using System.Reflection;
    using System.Threading.Tasks;

    using Shouldly;

    public sealed class AssertionSteps
    {
        MethodInfo assertionStep;
        MethodInfo additionalAssertionStep;
        MethodInfo otherMethod;
        MethodInfo methodWithParameter;
        MethodInfo methodWithReturnValue;

        public void When_detecting_assertion_steps()
        {
            assertionStep = Method("Then_a_result_can_be_verified");
            additionalAssertionStep = Method("And_then_another_result_can_be_verified");
            otherMethod = Method("ToString");
            methodWithParameter = Method("And_then_a_method_with_parameters_is_no_assertion_step");
            methodWithReturnValue = Method("And_then_a_method_with_return_value_is_no_assertion_step");
        }

        public void Then_setup_steps_are_detected_as_setup_steps()
        {
            assertionStep.IsAssertionStep().ShouldBeTrue();
        }

        public void And_then_additional_assertion_steps_are_detected_as_additional_assertion_steps()
        {
            additionalAssertionStep.IsAssertionStep().ShouldBeTrue();
        }

        public void And_then_other_methods_are_not_detected_as_assertion_steps()
        {
            otherMethod.IsAssertionStep().ShouldBeFalse();
        }

        public void And_then_methods_with_parameters_are_not_detected_as_assertion_steps()
        {
            methodWithParameter.IsAssertionStep().ShouldBeFalse();
        }

        public void And_then_methods_with_return_values_are_not_detected_as_assertion_steps()
        {
            methodWithReturnValue.IsAssertionStep().ShouldBeFalse();
        }

        static MethodInfo Method(string methodName)
        {
            return typeof(SpecificationWithAssertionSteps).GetInstanceMethod(methodName);
        }

        sealed class SpecificationWithAssertionSteps
        {
            public void Then_a_result_can_be_verified()
            {
            }

            public async Task And_then_another_result_can_be_verified()
            {
                await Task.FromResult(true);
            }

            public void And_then_a_method_with_parameters_is_no_assertion_step(int parameter)
            {
                var notUsed = parameter;

            }

            public int And_then_a_method_with_return_value_is_no_assertion_step()
            {
                return 0;
            }
        }
    }
}
