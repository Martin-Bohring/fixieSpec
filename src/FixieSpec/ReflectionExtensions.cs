// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Fixie;

    /// <summary>
    /// An extension class that contains methods to simplify reflection based code
    /// and make it more expressive.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Detects if the method given by <paramref name="method"/> has any parameters.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method has parameters; <see langword="false"/> otherwise.
        /// </returns>
        public static bool HasNoParameters(this MethodBase method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return !method.GetParameters().Any();
        }

        /// <summary>
        /// Detects if the type given by <see paramref="type"/> has only a default constructor.
        /// </summary>
        /// <param name="type">
        /// The type to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the type given by <paramref name="type"/> has a only default constructor;
        /// <see langword="false"/> otherwise.
        /// </returns>
        public static bool HasOnlyDefaultConstructor(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type
                .GetConstructors()
                .All(constructorInfo => constructorInfo.HasNoParameters());
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

            return method.HasNoParameters() &&
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

            return method.IsPublic &&
                method.HasNoParameters() &&
                method.IsVoid() &&
                method.ScanMethod() == SpecificationStepType.Assertion;
        }
    }
}
