// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fixie.Execution;
    using Shouldly;

    public sealed class FixieSpecConventionTests
    {
        public void ShouldExecuteSimpleSuccessfullSpecification()
        {
            var listener = new StubCaseResultListener();

            typeof(SimpleSuccessfullSpecification).Run(listener, new FixieSpecConvention());

            listener.Log.OfType<PassResult>().Count().ShouldBe(1);
            listener.Log.OfType<FailResult>().Count().ShouldBe(0);
        }

        public void ShouldExecuteSimpleFailingSpecification()
        {
            var listener = new StubCaseResultListener();

            typeof(SimpleFailingSpecification).Run(listener, new FixieSpecConvention());

            listener.Log.OfType<FailResult>().Count().ShouldBe(1);
            listener.Log.OfType<PassResult>().Count().ShouldBe(0);
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

        public class StubCaseResultListener : Listener
        {
            public List<CaseResult> Log { get; set; } = new List<CaseResult>();

            public void AssemblyStarted(AssemblyInfo assembly) { }

            public void CaseSkipped(SkipResult result) => Log.Add(result);
            public void CasePassed(PassResult result) => Log.Add(result);
            public void CaseFailed(FailResult result) => Log.Add(result);

            public void AssemblyCompleted(AssemblyInfo assembly, AssemblyResult result) { }
        }
    }
}
