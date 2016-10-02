// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Reflection;

    using Shouldly;

    public sealed class MethodBaseExtensionsTests
    {
        public void ShouldDetectMethodWithoutParameters()
        {
            var methodWithoutParameter = Method("MethodWithoutParameter");

            methodWithoutParameter.HasNoParameters().ShouldBeTrue();
            methodWithoutParameter.HasParameters().ShouldBeFalse();
        }

        public void ShouldDetectMethodWithParameter()
        {
            var methodWithParameter = Method("MethodWithParammeter");

            methodWithParameter.HasNoParameters().ShouldBeFalse();
            methodWithParameter.HasParameters().ShouldBeTrue();
        }

        static MethodInfo Method(string methodName)
        {
            return typeof(TypeWithMethods).GetInstanceMethod(methodName);
        }

        class TypeWithMethods
        {
            public void MethodWithoutParameter()
            {
            }

            public void MethodWithParammeter(int value)
            {
                var notUsed = value;
            }
        }
    }
}
