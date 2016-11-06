// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The conventions a scenario is expected to fulfill.
    /// </summary>
    public static class ScenarioConventions
    {
        /// <summary>
        /// Identifies the setup steps of the scenario given by <paramref name="scenario"/>
        /// </summary>
        /// <param name="scenario">
        /// The scenario defining the setup steps.
        /// </param>
        /// <returns>
        /// The setup steps of the scenario in execution order.
        /// </returns>
        public static IEnumerable<MethodInfo> SetupSteps(this Type scenario)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException(nameof(scenario));
            }

            return scenario.GetInstanceMethods().Where(method => method.GetRoleInScenario() == StepRoleInScenario.Setup);
        }
    }
}
