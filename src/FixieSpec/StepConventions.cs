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
                StepType.Setup);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndGiven", StringComparison.OrdinalIgnoreCase),
                    StepType.AdditionalSetup);

            AddStepConvention(
                    methodName => methodName.StartsWith("When", StringComparison.OrdinalIgnoreCase),
                    StepType.Transition);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndWhen", StringComparison.OrdinalIgnoreCase),
                    StepType.Transition);

            AddStepConvention(
                    methodName => methodName.StartsWith("Then", StringComparison.OrdinalIgnoreCase),
                    StepType.Assertion);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndThen", StringComparison.OrdinalIgnoreCase),
                    StepType.Assertion);
        }

        enum StepType
        {
            Undefined,
            Setup,
            AdditionalSetup,
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
            return method.IsPrimarySetupStep() || method.IsAdditionalSetupStep();
        }

        /// <summary>
        /// Detects if the method given by <paramref name="method"/> is a primary setup step.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method is a primary setup step; <see langword="false"/> otherwise.
        /// </returns>
        public static bool IsPrimarySetupStep(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.HasStepSignature() && method.ScanMethod() == StepType.Setup;
        }

        /// <summary>
        /// Detects if the method given by <paramref name="method"/> is an additional setup step.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method is an additional setup step; <see langword="false"/> otherwise.
        /// </returns>
        public static bool IsAdditionalSetupStep(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.HasStepSignature() && method.ScanMethod() == StepType.AdditionalSetup;
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
                   method.ScanMethod() == StepType.Transition;
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
                   method.ScanMethod() == StepType.Assertion;
        }

        static bool HasStepSignature(this MethodInfo method) => method.IsPublic &&
                method.HasNoParameters() &&
                (method.IsVoid() || method.IsAsync());

        static StepType ScanMethod(this MethodInfo methodToScan)
        {
            foreach (var stepConvention in Conventions)
            {
                var matchResult = stepConvention.MatchMethodName(methodToScan.ScrubMethodName());

                if (matchResult != StepType.Undefined)
                {
                    return matchResult;
                }
            }

            return StepType.Undefined;
        }

        static void AddStepConvention(Func<string, bool> methodNameMatcher, StepType stepTypeIfMatched)
            => Conventions.Add(new StepConvention(methodNameMatcher, stepTypeIfMatched));

        static string ScrubMethodName(this MethodInfo methodToMatch)
            => methodToMatch.Name.Replace(@"_", string.Empty);

        class StepConvention
        {
            readonly Func<string, bool> matcher;

            readonly StepType stepType;

            public StepConvention(Func<string, bool> methodNameMatcher, StepType stepTypeIfMatched)
            {
                stepType = stepTypeIfMatched;
                matcher = methodNameMatcher;
            }

            public StepType MatchMethodName(string methodName)
            {
                if (matcher(methodName))
                {
                    return stepType;
                }

                return StepType.Undefined;
            }
        }
    }
}
