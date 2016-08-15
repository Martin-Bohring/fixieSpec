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
    /// The conventions used to identify specification steps.
    /// </summary>
    public static class StepConventions
    {
        static readonly ConcurrentBag<StepConvention> Conventions
            = new ConcurrentBag<StepConvention>();

        /// <summary>
        /// Initializes static members of the <see cref="StepConventions"/> class.
        /// </summary>
        static StepConventions()
        {
            AddStepConvention(
                methodName => methodName.StartsWith("Given", StringComparison.OrdinalIgnoreCase),
                SpecificationStepType.Setup);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndGiven", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.SecondarySetup);

            AddStepConvention(
                    methodName => methodName.StartsWith("When", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Transition);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndWhen", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Transition);

            AddStepConvention(
                    methodName => methodName.StartsWith("Then", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Assertion);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndThen", StringComparison.OrdinalIgnoreCase),
                    SpecificationStepType.Assertion);
        }

        enum SpecificationStepType
        {
            Undefined,
            Setup,
            SecondarySetup,
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

            if (method.HasStepSignature())
            {
                var stepType = method.ScanMethod();

                return (stepType == SpecificationStepType.Setup) || (stepType == SpecificationStepType.SecondarySetup);
            }

            return false;
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

        static bool HasStepSignature(this MethodInfo method) => method.IsPublic &&
                method.HasNoParameters() &&
                (method.IsVoid() || method.IsAsync());

        static SpecificationStepType ScanMethod(this MethodInfo methodToScan)
        {
            foreach (var stepConvention in Conventions)
            {
                var matchResult = stepConvention.MatchMethodName(methodToScan.ScrubMethodName());

                if (matchResult != SpecificationStepType.Undefined)
                {
                    return matchResult;
                }
            }

            return SpecificationStepType.Undefined;
        }

        static void AddStepConvention(Func<string, bool> methodNameMatcher, SpecificationStepType stepTypeIfMatched)
            => Conventions.Add(new StepConvention(methodNameMatcher, stepTypeIfMatched));

        static string ScrubMethodName(this MethodInfo methodToMatch)
            => methodToMatch.Name.Replace(@"_", string.Empty);

        class StepConvention
        {
            readonly Func<string, bool> matcher;

            readonly SpecificationStepType stepType;

            public StepConvention(Func<string, bool> methodNameMatcher, SpecificationStepType stepTypeIfMatched)
            {
                stepType = stepTypeIfMatched;
                matcher = methodNameMatcher;
            }

            public SpecificationStepType MatchMethodName(string methodName)
            {
                if (matcher(methodName))
                {
                    return stepType;
                }

                return SpecificationStepType.Undefined;
            }
        }
    }
}
