// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Collections.Concurrent;
    using System.Reflection;

    using Fixie;

    /// <summary>
    /// A class that detects the specification steps of a specification type.
    /// </summary>
    public static class SpecificationStepScanner
    {
        static readonly ConcurrentBag<MethodNameScanner> MethodNameScanners
            = new ConcurrentBag<MethodNameScanner>();

        /// <summary>
        /// Initializes static members of the <see cref="SpecificationStepScanner"/> class.
        /// </summary>
        static SpecificationStepScanner()
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

        enum SpecificationStepType
        {
            Undefined,
            Setup,
            Transition,
            Assertion
        }

        /// <summary>
        /// Detects if the method given by <paramref name="method"/> is a setup step.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method is a setup step; <see langword="false"/> otherwise.
        /// </returns>
        public static bool IsSetupStep(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.HasStepSignature() &&
                   method.ScanMethod() == SpecificationStepType.Setup;
        }

        /// <summary>
        /// Detects if the method given by <paramref name="method"/> is a transition step.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method is an transition step; <see langword="false"/> otherwise.
        /// </returns>
        public static bool IsTransitionStep(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.HasStepSignature() &&
                   method.ScanMethod() == SpecificationStepType.Transition;
        }

        /// <summary>
        /// Detects if the method given by <paramref name="method"/> is an assertion step.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method is an assertion step; <see langword="false"/> otherwise.
        /// </returns>
        public static bool IsAssertionStep(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.HasStepSignature() &&
                   method.ScanMethod() == SpecificationStepType.Assertion;
        }

        static bool HasStepSignature(this MethodInfo method)
        {
            return method.IsPublic &&
                method.HasNoParameters() &&
                method.IsVoid();
        }

        static SpecificationStepType ScanMethod(this MethodInfo methodToScan)
        {
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
