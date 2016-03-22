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
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.FirstMethod()),
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.SecondMethod()));

            result.ShouldBe(-1);
        }

        public void ShouldDeclareNullMethodAsEarlier()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                null as MethodInfo,
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.FirstMethod()));

            result.ShouldBe(-1);
        }

        public void ShouldCompareLaterDeclaredMembersAsAfter()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.SecondMethod()),
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.FirstMethod()));

            result.ShouldBe(1);
        }

        public void ShouldCompareTheSameMemberAsSame()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.FirstMethod()),
                SymbolExtensions.GetMethodInfo<ClassWithDeclarations>(c => c.FirstMethod()));

            result.ShouldBe(0);
        }

        public void ShouldCompareBothNullAsSame()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(null as MethodInfo, null as MethodInfo);

            result.ShouldBe(0);
        }

        public void ShouldCompareTheSameWithBothOperandsNull()
        {
            var testee = new DeclarationOrderComparer<MethodInfo>();

            var result = testee.Compare(
                null as MethodInfo,
                null as MethodInfo);

            result.ShouldBe(0);
        }

        sealed class ClassWithDeclarations
        {
            public void FirstMethod()
            {
            }

            public void SecondMethod()
            {
            }
        }
    }
}
