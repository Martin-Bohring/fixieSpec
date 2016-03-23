// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// A helper class to refactor safe access <see cref="MethodInfo"/> idendified by an expression
    /// instead of a string.
    /// </summary>
    /// <remarks>
    /// Taken from http://blog.functionalfun.net/search/label/LINQ, but all errors are mine. I would
    /// like to turn those into real extension methods, but that is not possible. An <see
    /// cref="Expression"/> itself does not have a type until evaluated, therefore one can't extend
    /// an unknown type.
    /// </remarks>
    public static class SymbolExtensions
    {
        /// <summary>
        /// Given a lambda expression that identifies a method, returns the <see cref="MethodInfo"/>
        /// of the method.
        /// </summary>
        /// <param name="expression">
        /// The expression that identifies a method.
        /// </param>
        /// <returns>
        /// The <see cref="MethodInfo"/> identified by the <paramref name="expression"/>.
        /// </returns>
        public static MethodInfo GetMethodInfo(Expression<Action> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }

        /// <summary>
        /// Given a lambda expression that identifies a method, returns the <see cref="MethodInfo"/>
        /// of the method.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the only parameter of the method being identified.
        /// </typeparam>
        /// <param name="expression">
        /// The expression that identifies a method.
        /// </param>
        /// <returns>
        /// The <see cref="MethodInfo"/> identified by the <paramref name="expression"/>.
        /// </returns>
        public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }

        /// <summary>
        /// Given a lambda expression that identifies a method, returns the <see cref="MethodInfo"/>
        /// of the method.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the only parameter of the method being identified.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the return value of the method being identified.
        /// </typeparam>
        /// <param name="expression">
        /// The expression that identifies a method.
        /// </param>
        /// <returns>
        /// The <see cref="MethodInfo"/> identified by the <paramref name="expression"/>.
        /// </returns>
        public static MethodInfo GetMethodInfo<T, TResult>(Expression<Func<T, TResult>> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }

        /// <summary>
        /// Given a lambda expression that identifies a method, returns the <see cref="MethodInfo"/>
        /// of the method.
        /// </summary>
        /// <param name="expression">
        /// The expression that identifies a method.
        /// </param>
        /// <returns>
        /// The <see cref="MethodInfo"/> identified by the <paramref name="expression"/>.
        /// </returns>
        public static MethodInfo GetMethodInfo(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;

            if (outermostExpression == null)
            {
                throw new ArgumentException("Invalid Expression. Expression should consist of a Method call only.", nameof(expression));
            }

            return outermostExpression.Method;
        }
    }
}