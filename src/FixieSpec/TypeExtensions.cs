// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Linq;

    /// <summary>
    /// An extension class that contains methods to simplify reflection on types
    /// and make it more expressive.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Detects if the type given by <see paramref="type"/> has only a default constructor.
        /// </summary>
        /// <param name="type">
        /// The type to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the type given by <paramref name="type"/> has a
        /// only default constructor; <see langword="false"/> otherwise.
        /// </returns>
        public static bool HasOnlyDefaultConstructor(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.HasSingleConstuctor() &&
                   type.GetConstructors().Count(constructorInfo => constructorInfo.HasNoParameters()) == 1;
        }

        /// <summary>
        /// Detects if the type given by <see paramref="type"/> has only a constructor
        /// with with parameters.
        /// </summary>
        /// <param name="type">
        /// The type to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the type given by <paramref name="type"/> has a only a
        /// constructor with parameters; <see langword="false"/> otherwise.
        /// </returns>
        public static bool HasOnlyParameterConstructor(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.HasSingleConstuctor() &&
                   type.GetConstructors().Count(constructorInfo => constructorInfo.HasParameters()) == 1;
        }

        static bool HasSingleConstuctor(this Type type)
        {
            return type.GetConstructors().Count() == 1;
        }
    }
}
