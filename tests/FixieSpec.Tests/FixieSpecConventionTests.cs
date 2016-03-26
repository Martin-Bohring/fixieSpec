// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using FakeItEasy;
    using Fixie.Execution;

    public sealed class FixieSpecConventionTests
    {
        public void ShouldExecuteSimpleSpecification()
        {
            var listener = A.Fake<Listener>();

            typeof(SimpleSpecification).Run(listener, new FixieSpecConvention());

            A.CallTo(() => listener.CasePassed(A<PassResult>._)).MustHaveHappened();
        }

        class SimpleSpecification
        {
            public void When_executing_a_test_step()
            {
            }

            public void Then_a_test_result_can_be_verified()
            {
            }
        }
    }
}
