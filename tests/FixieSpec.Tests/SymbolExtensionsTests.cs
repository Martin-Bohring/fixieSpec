// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System;
    using System.Linq;

    using Shouldly;
    public class SymbolExtensionsTests
    {
        public void ShouldGetMethodInfoForPublicMethod()
        {
            var methodInfo = SymbolExtensions.GetMethodInfo<TestClass>(c => c.AMethod());
            methodInfo.Name.ShouldBe("AMethod");
        }

        public void ShouldGetMethodInfoForGenericPublicMethod()
        {
            var methodInfo = SymbolExtensions.GetMethodInfo<TestClass>(c => c.AGenericMethod(default(int)));

            methodInfo.Name.ShouldBe("AGenericMethod");
            methodInfo.GetParameters().First().ParameterType.ShouldBe(typeof(int));
        }

        public void ShouldGetMethodInfoForStaticMethodOnStaticClass()
        {
            var methodInfo = SymbolExtensions.GetMethodInfo(() => StaticTestClass.StaticTestMethod());

            methodInfo.Name.ShouldBe("StaticTestMethod");
            methodInfo.IsStatic.ShouldBeTrue();
        }

        public void ShoulfFailForInvalidExpressions()
        {
            Action act = () => SymbolExtensions.GetMethodInfo(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShoulfFailForNonMethodExpressions()
        {
            Action act = () => SymbolExtensions.GetMethodInfo<TestClass>(c => new TestClass());

            act.ShouldThrow<ArgumentException>();
        }

        class TestClass
        {
            public void AMethod()
            {
            }

            public void AGenericMethod<T>(T parameter)
            {
            }
        }

        static class StaticTestClass
        {
            public static void StaticTestMethod()
            {
            }
        }
    }
}
