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
    /// An extension class that contains methods to simplify reflection based code
    /// and make it more expressive.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Checks if the met^hod given by <paramref name="method"/> has any pparameters.
        /// </summary>
        /// <param name="method">
        /// The method to check.
        /// </param>
        /// <returns>
        /// true, if the method has parameters; false otherwise.
        /// </returns>
        public static bool HasNoParameters(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return !method.GetParameters().Any();
        }
    }
}
