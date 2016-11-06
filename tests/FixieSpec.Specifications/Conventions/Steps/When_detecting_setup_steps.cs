// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Conventions.Steps
{
    using System.Reflection;

    using Shouldly;

    public sealed class When_detecting_setup_steps
    {
        readonly MethodInfo setupStep = Method("Given_a_setup_step");
        readonly MethodInfo additionalSetupStep = Method("And_given_an_additional_setup_step");
        readonly MethodInfo otherMethod = Method("ToString");

        public void Then_setup_steps_are_detected_as_setup_steps()
        {
            setupStep.IsSetupStep().ShouldBeTrue();
        }

        public void And_then_additional_setup_steps_are_detected_as_setup_steps()
        {
            additionalSetupStep.IsSetupStep().ShouldBeTrue();
        }

        public void And_then_other_methods_are_not_detected_as_setup_steps()
        {
            otherMethod.IsSetupStep().ShouldBeFalse();
        }
        static MethodInfo Method(string methodName)
        {
            return typeof(SpecificationWithSetupSteps).GetInstanceMethod(methodName);
        }

        sealed class SpecificationWithSetupSteps
        {
            public void Given_a_setup_step()
            {
            }

            public void And_given_an_additional_setup_step()
            {
            }
        }
    }
}
