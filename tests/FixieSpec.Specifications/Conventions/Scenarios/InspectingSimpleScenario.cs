// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Conventions.Scenarios
{
    using System.Collections.Generic;

    using System.Reflection;

    public sealed class InspectingSimpleScenario
    {
        readonly IEnumerable<MethodInfo> setupSteps = typeof(SimpleScenario).SetupSteps();

        public void When_inspecting_a_simple_scenario()
        {
        }

        [Inconclusive]
        public void Then_setup_steps_are_detected_in_order()
        {
            setupSteps.ShouldEqual(
                Method("Given_a_setup_step"),
                Method("And_given_another_stetup_step"));
        }

        [Inconclusive]
        public void And_then_transition_steps_are_detected_in_order()
        {
        }

        [Inconclusive]
        public void And_then_assertion_steps_are_detected_in_order()
        {
        }

        static MethodInfo Method(string methodName)
        {
            return typeof(SimpleScenario).GetInstanceMethod(methodName);
        }

        sealed class SimpleScenario
        {
            public void Given_a_setup_step()
            {
            }

            public void And_given_another_stetup_step()
            {
            }

            public void When_executing_a_transition_step()
            {
            }

            public void And_executing_another_transition_step()
            {
            }

            public void Then_a_result_can_be_verified()
            {
            }

            public void And_then_another_result_can_be_verified()
            {
            }
        }
    }
}
