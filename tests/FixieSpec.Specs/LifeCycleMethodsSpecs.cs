// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

using System;
using System.Text;

namespace FixieSpec.Specs
{
    class LifeCycleMethodsSpecs : IDisposable
    {
        readonly StringBuilder methodCallLogger = new StringBuilder();

        public void Given_a_specification()
        {
            methodCallLogger.WhereAmI();
        }

        public void Dispose()
        {
            methodCallLogger.ShouldHaveLines("Given_a_specification");
        }
    }
}
