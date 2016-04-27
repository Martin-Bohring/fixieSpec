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
        readonly MethodInfo firstMethod = typeof(ClassWithDeclarations).GetInstanceMethod("FirstMethod");
        readonly MethodInfo secondMethod = typeof(ClassWithDeclarations).GetInstanceMethod("SecondMethod");

        readonly DeclarationOrderComparer testee = DeclarationOrderComparer.Default;

        public void ShouldCompareEarlierDeclaredMembersAsBefore()
        {
            var result = testee.Compare(
                firstMethod,
                secondMethod);

            result.ShouldBe(-1);
        }

        public void ShouldDeclareNullMethodAsEarlier()
        {
            var result = testee.Compare(
                null as MethodInfo,
                firstMethod);

            result.ShouldBe(-1);
        }

        public void ShouldCompareLaterDeclaredMembersAsAfter()
        {
            var result = testee.Compare(
                secondMethod,
                firstMethod);

            result.ShouldBe(1);
        }

        public void ShouldCompareTheSameMemberAsSame()
        {
            var result = testee.Compare(
                firstMethod,
                firstMethod);

            result.ShouldBe(0);
        }

        public void ShouldCompareBothNullAsSame()
        {
            var result = testee.Compare(null as MethodInfo, null as MethodInfo);

            result.ShouldBe(0);
        }

        public void ShouldAlwaysReturnTheSameInstanceAsDefault()
        {
            var firstDefaultInstance = DeclarationOrderComparer.Default;
            var secondDefaultInstance = DeclarationOrderComparer.Default;

            var isSameInstance = ReferenceEquals(firstDefaultInstance, secondDefaultInstance);

            isSameInstance.ShouldBeTrue();
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
