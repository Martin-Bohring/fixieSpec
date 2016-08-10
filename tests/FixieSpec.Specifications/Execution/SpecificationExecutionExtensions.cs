// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fixie;
    using Fixie.Execution;
    using Fixie.Internal;

    static class SpecificationExecutionExtensions
    {
        public static AssemblyResult Run(this Type sampleTestClass, Listener listener, Convention convention)
        {
            return new Runner(listener).RunTypes(sampleTestClass.Assembly, convention, sampleTestClass);
        }

        public static IEnumerable<string> Lines(this RedirectedConsole console)
        {
            return console.Output.Lines();
        }

        public static IEnumerable<string> Lines(this string multiline)
        {
            var lines = multiline.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            while (lines.Count > 0 && lines[lines.Count - 1] == string.Empty)
            {
                lines.RemoveAt(lines.Count - 1);
            }

            return lines;
        }
    }
}
