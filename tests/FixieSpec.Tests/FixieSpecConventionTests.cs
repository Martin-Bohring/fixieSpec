// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;

    using FakeItEasy;
    using Fixie.Execution;

    public sealed class FixieSpecConventionTests
    {
        public void ShouldExecuteSimpleSuccessfullSpecification()
        {
            var listener = A.Fake<Listener>();

            typeof(SimpleSuccessfullSpecification).Run(listener, new FixieSpecConvention());

            A.CallTo(() => listener.CasePassed(A<PassResult>._)).MustHaveHappened();
            A.CallTo(() => listener.CaseFailed(A<FailResult>._)).MustNotHaveHappened();
        }

        public void ShouldExecuteSimpleFailingSpecification()
        {
            var listener = A.Fake<Listener>();

            typeof(SimpleFailingSpecification).Run(listener, new FixieSpecConvention());

            A.CallTo(() => listener.CaseFailed(A<FailResult>._)).MustHaveHappened();
            A.CallTo(() => listener.CasePassed(A<PassResult>._)).MustNotHaveHappened();
        }

        class SimpleSuccessfullSpecification
        {
            public void Then_a_successfull_test_result_can_be_verified()
            {
            }
        }

        class SimpleFailingSpecification
        {
            public void Then_a_failing_test_result_can_be_verified()
            {
                throw new InvalidOperationException();
            }
        }
    }
}
