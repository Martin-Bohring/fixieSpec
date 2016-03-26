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
    /// Scans the methods of a specification and identifies the <see cref="SpecificationStepType"/> of the specification methods.
    /// </summary>
    public static class SpecificationStepTypeScanner
    {
        static readonly ConcurrentQueue<MethodNameScanner> MethodNameScanners = new ConcurrentQueue<MethodNameScanner>();

        /// <summary>
        /// Initializes static members of the <see cref="SpecificationStepTypeScanner"/> class.
        /// </summary>
        static SpecificationStepTypeScanner()
        {
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("Given", StringComparison.OrdinalIgnoreCase), SpecificationStepType.Given));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("When", StringComparison.OrdinalIgnoreCase), SpecificationStepType.When));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("AndWhen", StringComparison.OrdinalIgnoreCase), SpecificationStepType.When));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("Then", StringComparison.OrdinalIgnoreCase), SpecificationStepType.Then));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("AndThen", StringComparison.OrdinalIgnoreCase), SpecificationStepType.Then));
        }

        /// <summary>
        /// Scans the method given by <paramref name="methodToScan"/> for its <see cref="SpecificationStepType"/>.
        /// </summary>
        /// <param name="methodToScan">
        /// The method to scan.
        /// </param>
        /// <returns>
        /// The type of the scanned method.
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

        /// <summary>
        /// Adds a method name scanner to the list of <see cref="MethodNameScanner"/>'s.
        /// </summary>
        /// <param name="methodNameScanner">
        /// The method name scanner to add.
        /// </param>
        static void AddMethodNameScanner(MethodNameScanner methodNameScanner)
        {
            MethodNameScanners.Enqueue(methodNameScanner);
        }

        /// <summary>
        /// A class that matches method names to identify the method type.
        /// </summary>
        class MethodNameScanner
        {
            readonly Func<string, bool> matcher;

            readonly SpecificationStepType methodType;

            /// <summary>
            /// Initializes a new instance of the <see cref="MethodNameScanner"/> class.
            /// </summary>
            /// <param name="methodMatcher">
            /// A function that attemps to match a test method by its name or parts of it.
            /// </param>
            /// <param name="methodTypeIfMatched">
            /// The type of the method if matched by the <paramref name="methodMatcher"/>.
            /// </param>
            public MethodNameScanner(Func<string, bool> methodMatcher, SpecificationStepType methodTypeIfMatched)
            {
                methodType = methodTypeIfMatched;
                matcher = methodMatcher;
            }

            /// <summary>
            /// Uses the emthod matcher to match the method given by <paramref name="methodToMatch"/>
            /// </summary>
            /// <param name="methodToMatch">
            /// The method the method name is matched for.
            /// </param>
            /// <returns>
            /// The type of the method if the method can be macthed or <see cref="SpecificationStepType.Undefined"/>.
            /// </returns>
            public SpecificationStepType MatchMethod(MethodInfo methodToMatch)
            {
                if (matcher(ScrubMethodName(methodToMatch)))
                {
                    return methodType;
                }

                return SpecificationStepType.Undefined;
            }

            /// <summary>
            /// Scrubs the name of the method to scan, before attempting to match it.
            /// </summary>
            /// <param name="methodToMatch">
            /// The method the name is being scrubbed.
            /// </param>
            /// <returns>
            /// The scrubbed metod name.
            /// </returns>
            static string ScrubMethodName(MethodInfo methodToMatch)
            {
                return methodToMatch.Name.Replace("_", string.Empty);
            }
        }
    }
}
