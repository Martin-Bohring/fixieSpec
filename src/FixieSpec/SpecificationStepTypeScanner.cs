// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Collections.Concurrent;
    using System.Reflection;

    /// <summary>
    /// A class that scans methods (of a specification) and identifies
    /// the <see cref="SpecificationStepType"/> of the methods.
    /// </summary>
    public static class SpecificationStepTypeScanner
    {
        static readonly ConcurrentBag<MethodNameScanner> MethodNameScanners
            = new ConcurrentBag<MethodNameScanner>();

        /// <summary>
        /// Initializes static members of the <see cref="SpecificationStepTypeScanner"/> class.
        /// </summary>
        static SpecificationStepTypeScanner()
        {
            AddMethodNameScanner(
                new MethodNameScanner(
                    methodName => methodName.StartsWith("Given", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Setup));

            AddMethodNameScanner(
                new MethodNameScanner(
                    methodName => methodName.StartsWith("AndGiven", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Setup));

            AddMethodNameScanner(
                new MethodNameScanner(
                    methodName => methodName.StartsWith("When", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Transition));

            AddMethodNameScanner(
                new MethodNameScanner(
                    methodName => methodName.StartsWith("AndWhen", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Transition));

            AddMethodNameScanner(
                new MethodNameScanner(
                    methodName => methodName.StartsWith("Then", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Assertion));

            AddMethodNameScanner(
                new MethodNameScanner(
                    methodName => methodName.StartsWith("AndThen", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Assertion));
        }

        /// <summary>
        /// Scans the method given by <paramref name="methodToScan"/> to identify its <see cref="SpecificationStepType"/>.
        /// </summary>
        /// <param name="methodToScan">
        /// The method to scan.
        /// </param>
        /// <returns>
        /// The <see cref="SpecificationStepType"/> of the scanned method.
        /// </returns>
        public static SpecificationStepType ScanMethod(this MethodInfo methodToScan)
        {
            if (methodToScan == null)
            {
                throw new ArgumentNullException(nameof(methodToScan));
            }

            foreach (var methodNameScanner in MethodNameScanners)
            {
                var matchResult = methodNameScanner.MatchMethod(methodToScan);

                if (matchResult != SpecificationStepType.Undefined)
                {
                    return matchResult;
                }
            }

            return SpecificationStepType.Undefined;
        }

        static void AddMethodNameScanner(MethodNameScanner methodNameScanner)
        {
            MethodNameScanners.Add(methodNameScanner);
        }

        class MethodNameScanner
        {
            readonly Func<string, bool> matcher;

            readonly SpecificationStepType methodType;

            public MethodNameScanner(Func<string, bool> methodMatcher, SpecificationStepType methodTypeIfMatched)
            {
                methodType = methodTypeIfMatched;
                matcher = methodMatcher;
            }

            public SpecificationStepType MatchMethod(MethodInfo methodToMatch)
            {
                if (matcher(ScrubMethodName(methodToMatch)))
                {
                    return methodType;
                }

                return SpecificationStepType.Undefined;
            }

            static string ScrubMethodName(MethodInfo methodToMatch) => methodToMatch.Name.Replace(@"_", string.Empty);
        }
    }
}
