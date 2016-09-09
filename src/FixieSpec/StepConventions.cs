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
                RoleInScenario.Setup);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndGiven", StringComparison.OrdinalIgnoreCase),
                    RoleInScenario.AdditionalSetup);

            AddStepConvention(
                    methodName => methodName.StartsWith("When", StringComparison.OrdinalIgnoreCase),
                    RoleInScenario.Transition);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndWhen", StringComparison.OrdinalIgnoreCase),
                    RoleInScenario.Transition);

            AddStepConvention(
                    methodName => methodName.StartsWith("Then", StringComparison.OrdinalIgnoreCase),
                    RoleInScenario.Assertion);

            AddStepConvention(
                    methodName => methodName.StartsWith("AndThen", StringComparison.OrdinalIgnoreCase),
                    RoleInScenario.Assertion);
        }

        enum RoleInScenario
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

            return method.HasStepSignature() && method.ScanMethod() == RoleInScenario.Setup;
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

            return method.HasStepSignature() && method.ScanMethod() == RoleInScenario.AdditionalSetup;
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
                   method.ScanMethod() == RoleInScenario.Transition;
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
                   method.ScanMethod() == RoleInScenario.Assertion;
        }

        static bool HasStepSignature(this MethodInfo method) => method.IsPublic &&
                method.HasNoParameters() &&
                (method.IsVoid() || method.IsAsync());

        static RoleInScenario ScanMethod(this MethodInfo methodToScan)
        {
            foreach (var stepConvention in Conventions)
            {
                var matchResult = stepConvention.MatchMethodName(methodToScan.ScrubMethodName());

                if (matchResult != RoleInScenario.Undefined)
                {
                    return matchResult;
                }
            }

            return RoleInScenario.Undefined;
        }

        static void AddStepConvention(Func<string, bool> methodNameMatcher, RoleInScenario stepTypeIfMatched)
            => Conventions.Add(new StepConvention(methodNameMatcher, stepTypeIfMatched));

        static string ScrubMethodName(this MethodInfo methodToMatch)
            => methodToMatch.Name.Replace(@"_", string.Empty);

        class StepConvention
        {
            readonly Func<string, bool> matcher;

            readonly RoleInScenario stepType;

            public StepConvention(Func<string, bool> methodNameMatcher, RoleInScenario stepTypeIfMatched)
            {
                stepType = stepTypeIfMatched;
                matcher = methodNameMatcher;
            }

            public RoleInScenario MatchMethodName(string methodName)
            {
                if (matcher(methodName))
                {
                    return stepType;
                }

                return RoleInScenario.Undefined;
            }
        }
    }
}
