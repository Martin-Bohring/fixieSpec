// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using Fixie.Execution;
    using Fixie.Internal;

    public abstract class ExecutionSpecificationBase
    {
        protected static SpecificationExecutionResult Execute<TSampleTestClass>()
        {
            using (var console = new RedirectedConsole())
            {
                var listener = new NullResultListener();

                var results = typeof(TSampleTestClass).Run(listener, new FixieSpecConvention());

                return new SpecificationExecutionResult(results, console.Lines());
            }
        }

        protected static void WhereAmI([CallerMemberName] string member = null)
        {
            Console.WriteLine(member);
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
