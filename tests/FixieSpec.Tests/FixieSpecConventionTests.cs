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

            listener.Log.Count.ShouldBe(1);
            listener.Log.OfType<PassResult>().Count().ShouldBe(1);
            listener.Log.OfType<FailResult>().Count().ShouldBe(0);
        }

        public void ShouldExecuteSimpleFailingSpecification()
        {
            var listener = new StubCaseResultListener();

            typeof(SimpleFailingSpecification).Run(listener, new FixieSpecConvention());

            listener.Log.Count.ShouldBe(1);
            listener.Log.OfType<FailResult>().Count().ShouldBe(1);
            listener.Log.OfType<PassResult>().Count().ShouldBe(0);
        }

        public void ShouldExecuteSpecificationWithMultipleVerificationSteps()
        {
            var listener = new StubCaseResultListener();

            typeof(MultipleVerificationStepsSpecification).Run(listener, new FixieSpecConvention());

            listener.Log.Count.ShouldBe(2);
            listener.Log.OfType<PassResult>().Count().ShouldBe(2);
            listener.Log.OfType<FailResult>().Count().ShouldBe(0);
        }

        public void ShouldExecuteMultipleVerificationStepsInOrder()
        {
            var listener = new StubCaseResultListener();

            typeof(MultipleVerificationStepsSpecification).Run(listener, new FixieSpecConvention());

            listener.Log.First().MethodGroup.Method.ShouldBe(
                SymbolExtensions.GetMethodInfo<MultipleVerificationStepsSpecification>(c => c.Then_a_test_result_can_be_verified()).Name);

            listener.Log.Last().MethodGroup.Method.ShouldBe(
                SymbolExtensions.GetMethodInfo<MultipleVerificationStepsSpecification>(c => c.Then_another_test_result_can_be_verified()).Name);
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

        class MultipleVerificationStepsSpecification
        {
            public void Then_a_test_result_can_be_verified()
            {
            }

            public void Then_another_test_result_can_be_verified()
            {
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
