// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    /// <summary>
    /// Describes the type of a specification step.
    /// </summary>
    public enum SpecificationStepType
    {
        /// <summary>
        /// The type of the step is unknown.
        /// </summary>
        Undefined,

        /// <summary>
        /// The step is a context setup step.
        /// </summary>
        Given,

        /// <summary>
        /// The step is an execution step,
        /// </summary>
        When,

        /// <summary>
        /// The step is a verification step.
        /// </summary>
        Then
    }
}
