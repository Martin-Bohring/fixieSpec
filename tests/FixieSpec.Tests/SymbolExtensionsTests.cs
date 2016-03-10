// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Linq;

    using Shouldly;

    public class SymbolExtensionsTests
    {
        public void GetMethodInfo_should_return_method_info()
        {
            var methodInfo = SymbolExtensions.GetMethodInfo<TestClass>(c => c.AMethod());
            methodInfo.Name.ShouldBe("AMethod");
        }

        public void GetMethodInfo_should_return_method_info_for_generic_method()
        {
            var methodInfo = SymbolExtensions.GetMethodInfo<TestClass>(c => c.AGenericMethod(default(int)));

            methodInfo.Name.ShouldBe("AGenericMethod");
            methodInfo.GetParameters().First().ParameterType.ShouldBe(typeof(int));
        }

        public void GetMethodInfo_should_return_method_info_for_static_method_on_static_class()
        {
            var methodInfo = SymbolExtensions.GetMethodInfo(() => StaticTestClass.StaticTestMethod());

            methodInfo.Name.ShouldBe("StaticTestMethod");
            methodInfo.IsStatic.ShouldBeTrue();
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
