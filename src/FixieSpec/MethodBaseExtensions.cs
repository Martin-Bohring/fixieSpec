// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// An extension class that contains methods to simplify reflection on methods
    /// and make it more expressive.
    /// </summary>
    public static class MethodBaseExtensions
    {
        /// <summary>
        /// Detects if the method given by <paramref name="method"/> has no parameters.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method has no parameters; <see langword="false"/> otherwise.
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
        /// Detects if the method given by <paramref name="method"/> has parameters.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the method has parameters; <see langword="false"/> otherwise.
        /// </returns>
        public static bool HasParameters(this MethodBase method)
        {
            return !method.HasNoParameters();
        }
    }
}
