// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution
{
    using System.Collections.Generic;

    using Fixie.Execution;
    using Shouldly;

    public class SpecificationExecutionResult
    {
        readonly AssemblyResult allResults;

        public SpecificationExecutionResult(AssemblyResult results, IEnumerable<string> consoleOutput)
        {
            allResults = results;
            ConsoleOutput = consoleOutput;
        }

        public IEnumerable<string> ConsoleOutput { get; private set; }

        public int Passed => allResults.Passed;

        public int Failed => allResults.Failed;

        public int Skipped => allResults.Skipped;

        public int Total => allResults.Total;

        public void ShouldHaveExecutedSteps(params string[] stepNames)
        {
            ConsoleOutput.ShouldEqual(stepNames);
        }

        public void ShouldNotHaveExecutedAnySteps()
        {
            ConsoleOutput.ShouldBeEmpty();
        }
    }
}
