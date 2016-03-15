// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Text;

    class SimpleSpec
    {
        readonly StringBuilder methodCallLogger = new StringBuilder();

        public void Given_a_simple_spec()
        {
            methodCallLogger.WhereAmI();
        }

        public void When_executing_a_test_step()
        {
            methodCallLogger.WhereAmI();
        }

        public void And_when_executing_a_second_test_step()
        {
            methodCallLogger.WhereAmI();
        }

        public void Then_a_test_result_can_be_verified()
        {
            methodCallLogger.WhereAmI();
        }

        public void And_then_a_second_result_can_be_verified()
        {
            methodCallLogger.WhereAmI();
        }
    }
}
