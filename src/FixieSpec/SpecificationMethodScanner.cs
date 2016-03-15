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
    /// Scans the methods of a specification and identifies the <see cref="MethodType"/> of the specification methods.
    /// </summary>
    public static class SpecificationMethodScanner
    {
        static ConcurrentQueue<MethodNameScanner> methodNameScanners = new ConcurrentQueue<MethodNameScanner>();

        /// <summary>
        /// Initializes static members of the <see cref="SpecificationMethodScanner"/> class.
        /// </summary>
        static SpecificationMethodScanner()
        {
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("Given", StringComparison.OrdinalIgnoreCase), MethodType.Given));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("When", StringComparison.OrdinalIgnoreCase), MethodType.When));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("AndWhen", StringComparison.OrdinalIgnoreCase), MethodType.When));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("Then", StringComparison.OrdinalIgnoreCase), MethodType.Then));
            AddMethodNameScanner(new MethodNameScanner(s => s.StartsWith("AndThen", StringComparison.OrdinalIgnoreCase), MethodType.Then));
        }

        /// <summary>
        /// Scans the method given by <paramref name="methodToScan"/> for its <see cref="MethodType"/>.
        /// </summary>
        /// <param name="methodToScan">
        /// The method to scan.
        /// </param>
        /// <returns>
        /// The type of the scanned method.
        /// </returns>
        public static MethodType ScanMethod(this MethodInfo methodToScan)
        {
            if (methodToScan == null)
            {
                throw new ArgumentNullException(nameof(methodToScan));
            }

            foreach (var methodNameScanner in methodNameScanners)
            {
                var matchResult = methodNameScanner.MatchMethod(methodToScan);

                if (matchResult != MethodType.Undefined)
                {
                    return matchResult;
                }
            }

            return MethodType.Undefined;
        }

        /// <summary>
        /// Adds a method name scanner to the list of <see cref="MethodNameScanner"/>'s.
        /// </summary>
        /// <param name="methodNameScanner">
        /// The method name scanner to add.
        /// </param>
        static void AddMethodNameScanner(MethodNameScanner methodNameScanner)
        {
            methodNameScanners.Enqueue(methodNameScanner);
        }

        /// <summary>
        /// A class that matches method names to identify the method type.
        /// </summary>
        class MethodNameScanner
        {
            readonly Func<string, bool> matcher;

            readonly MethodType methodType;

            /// <summary>
            /// Initializes a new instance of the <see cref="MethodNameScanner"/> class.
            /// </summary>
            /// <param name="methodMatcher">
            /// A function that attemps to match a test method by its name or parts of it.
            /// </param>
            /// <param name="methodTypeIfMatched">
            /// The type of the method if matched by the <paramref name="methodMatcher"/>.
            /// </param>
            public MethodNameScanner(Func<string, bool> methodMatcher, MethodType methodTypeIfMatched)
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
            /// The type of the method if the method can be macthed or <see cref="MethodType.Undefined"/>.
            /// </returns>
            public MethodType MatchMethod(MethodInfo methodToMatch)
            {
                if (matcher(ScrubMethodName(methodToMatch)))
                {
                    return methodType;
                }

                return MethodType.Undefined;
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
            private string ScrubMethodName(MethodInfo methodToMatch)
            {
                return methodToMatch.Name.Replace("_", string.Empty);
            }
        }
    }
}
