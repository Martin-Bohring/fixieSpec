// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution
{
    using System;
    using System.Runtime.CompilerServices;

    using Fixie.Execution;
    using Fixie.Internal;

    public abstract class ExecutionSpecificationBase
    {
        protected static SpecificationExecutionResult Execute<TSpecificationClass>()
        {
            using (var console = new RedirectedConsole())
            {
                var results = Execute(typeof(TSpecificationClass));

                return new SpecificationExecutionResult(results, console.Lines());
            }
        }

        protected static void RecordStep([CallerMemberName] string member = null)
        {
            Console.WriteLine(member);
        }

        static AssemblyResult Execute(Type specificationType)
        {
            return new Runner(new NullResultListener()).RunTypes(
                specificationType.Assembly,
                new FixieSpecConvention(),
                specificationType);
        }

        protected class NullResultListener : Listener
        {
            public void AssemblyStarted(AssemblyInfo assembly) { }

            public void CaseSkipped(SkipResult result) { }
            public void CasePassed(PassResult result) { }
            public void CaseFailed(FailResult result) { }

            public void AssemblyCompleted(AssemblyInfo assembly, AssemblyResult result) { }
        }
    }
}
