// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Tests
{
    using System.Reflection;

    using Shouldly;

    sealed class DeclarationOrderComparerTests
    {
        public void ShouldCompareEarlierDeclaredMembersAsBefore()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.When_executing_a_test_step()),
                SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_when_executing_a_second_test_step()));

            result.ShouldBe(-1);
        }

        public void ShouldCompareLaterDeclaredMembersAsAfter()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_when_executing_a_second_test_step()),
                SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.When_executing_a_test_step()));

            result.ShouldBe(1);
        }

        public void ShouldCompareTheSameMemberAsSame()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_when_executing_a_second_test_step()),
                SymbolExtensions.GetMethodInfo<SimpleSpec>(c => c.And_when_executing_a_second_test_step()));

            result.ShouldBe(0);
        }
    }
}
