// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Linq;

    using Shouldly;

    public sealed class SpecificationMethodScannerTests
    {
        public void ShouldNotScanNonTestMethodsAsTestMethods()
        {
            var nonTestMethod = typeof(object).GetMethods().First();

            var methodScanResult = nonTestMethod.ScanMethod();

            methodScanResult.ShouldBe(MethodType.Undefined);
        }

        public void ShouldScanContextMethodAsContextMethod()
        {
            var contextTestMethod = typeof(SimpleSpec).GetMethod("Given_a_simple_spec");

            var methodScanResult = contextTestMethod.ScanMethod();

            methodScanResult.ShouldBe(MethodType.Given);
        }
    }
}
