// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using Fixie;
    using Fixie.Execution;
    using Fixie.Internal;
    using System;

    /// <summary>
    /// Test helper extension class taken from
    /// https://github.com/fixie/fixie/blob/master/src/Fixie.Tests/TestExtensions.cs and stripped
    /// down to what is needed for the https://github.com/Martin-Bohring/fixieSpec tests.
    /// </summary>
    /// <remarks>
    /// We are taking a bet here and depend on the <see cref="Runner"/> class which is internal to http://fixie.github.io/.
    ///
    /// On the other hand I have found no good way of testing the <see cref="FixieSpecConvention"/>
    /// without using the runner. Also http://fixie.github.io/ itself is using the runner in several
    /// of its runners in a public way.
    /// </remarks>
    public static class TestExtensions
    {
        public static void Run(this Type sampleTestClass, Listener listener, Convention convention)
        {
            new Runner(listener).RunTypes(sampleTestClass.Assembly, convention, sampleTestClass);
        }
    }
}
