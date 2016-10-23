// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A base class for types with value sementics.
    /// </summary>
    /// <typeparam name="T">
    /// The type with value semantic.
    /// </typeparam>
    /// <remarks>
    /// This is an instance of the recurring template pattern for c#.
    /// https://en.wikipedia.org/wiki/Curiously_recurring_template_pattern
    /// It has been created to avoid writing the same boilerplate code again and again.
    /// </remarks>
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// The equality operator.
        /// </summary>
        /// <param name="lhs">
        /// The left hand side of the operator.
        /// </param>
        /// <param name="rhs">
        /// The right hand side of the operator.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the values of its operands are equal; <see langword="false"/> otherwise.
        /// </returns>
        public static bool operator ==(ValueObject<T> lhs, ValueObject<T> rhs)
        {
            return ReferenceEquals(lhs, null) || lhs.Equals(rhs);
        }

        /// <summary>
        /// The inequality operator.
        /// </summary>
        /// <param name="lhs">
        /// The left hand side of the operator.
        /// </param>
        /// <param name="rhs">
        /// The right hand side of the operator.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, if the values of its operands are not equal; <see langword="false"/> otherwise.
        /// </returns>
        public static bool operator !=(ValueObject<T> lhs, ValueObject<T> rhs) => !(lhs == rhs);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals(obj as T);
        }

        /// <inheritdoc/>
        public bool Equals(T other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Reflect().SequenceEqual(other.Reflect());
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Reflect().Aggregate(37, (hashCode, value) => hashCode ^ value?.GetHashCode() ?? hashCode);
        }

        /// <summary>
        /// Gest the values to be taken into account for equality and
        /// hash code generation.
        /// </summary>
        /// <returns>
        /// An enumeration of the values.
        /// </returns>
        /// <remarks>
        /// For true value semantics all values should be included.
        /// </remarks>
        protected abstract IEnumerable<object> Reflect();
    }
}
