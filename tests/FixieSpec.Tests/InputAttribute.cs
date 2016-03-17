// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;

    /// <summary>
    /// An attribute used to provide parameter input values to test methods
    /// declared in test fixture the <see cref="InputAttributeParameterSource"/>
    /// is being applied to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    sealed class InputAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputAttribute"/> class.
        /// </summary>
        /// <param name="parameters">
        /// The parameter input values in the order of the parameter declaration
        /// of the test method annotated with this attribute.
        /// </param>
        public InputAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the parameter values.
        /// </summary>
        public object[] Parameters { get; }
    }
}